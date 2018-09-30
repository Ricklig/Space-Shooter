using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {


    private Vector3 startPos;

    float speed = 3;
    float xScale = 4;
    float yScale = 2;
    float moveReset = 4.206591f;
    float moveTime;
    float runTime;

    float reset = 5;

    public GameObject bulletPrefab;
    public Transform gun;

    float shotsFired = 1;


    // Use this for initialization
    void Start () {
        startPos = transform.position;
        moveTime = moveReset;
    }
	
	// Update is called once per frame
	void Update () {
        
        if (moveTime > 0)
        {
            moveTime -= Time.deltaTime;
            transform.position = startPos + (Vector3.right * Mathf.Sin(runTime / 2 * speed) * xScale - Vector3.up * Mathf.Sin(runTime * speed) * yScale);
            runTime += Time.deltaTime;
        }
        else
        {
            reset -= Time.deltaTime;
            if (reset < 0)
            {
                moveTime = moveReset;
                reset = 5;
                runTime = 0;
            }
        }

        shotsFired -= Time.deltaTime;
        if (shotsFired < 0)
        {
            Fire();
            shotsFired = 1;
        }


    }


    void Fire()
    {
        Vector3 vectorToTarget = GameObject.FindWithTag("Player").GetComponent<Transform>().position - gameObject.transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle + 90, Vector3.forward);
        var bullet = (GameObject)Instantiate(bulletPrefab, gun.position, q);

    }
}

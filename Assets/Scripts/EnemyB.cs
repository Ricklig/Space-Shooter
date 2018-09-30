using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyB : MonoBehaviour {

    float CurveSpeed = 5;
    float MoveSpeed = 2;
    float fTime = 50;
    float runTime = 3.0f;
    
    public GameObject bulletPrefab;
    public Transform gun;

    float shotsFired = 2.0f;
    

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()

    {

        if (runTime > 0.5)
        {
            runTime -= Time.deltaTime;
            transform.Translate(-5f * Time.deltaTime, 1 * Time.deltaTime, 0.0f);
        }
        else
        {
            StartCoroutine(MoveSin());
        }

        shotsFired -= Time.deltaTime;
        if(shotsFired < 0)
        {
            Fire();
            shotsFired = 2.0f;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.layer.Equals(8))
        {

            Destroy(col.gameObject);
            gameObject.GetComponentInParent<EnemyBManager>().sendPos(gameObject.transform.position);
            Destroy(gameObject);
        }

        else if (col.gameObject.layer.Equals(9))
        {
            
            gameObject.GetComponentInParent<EnemyBManager>().noBonus();
            Destroy(gameObject);
        }

        else if (col.gameObject.layer.Equals(11))
        {
            
            col.gameObject.GetComponent<PlayerMove>().TakeDamage();
            gameObject.GetComponentInParent<EnemyBManager>().noBonus();
            Destroy(gameObject);
        }
    }

    void Fire()
    {
        Vector3 vectorToTarget = GameObject.FindWithTag("Player").GetComponent<Transform>().position - gameObject.transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle + 90, Vector3.forward);
        var bullet = (GameObject)Instantiate(bulletPrefab, gun.position, q );

    }

    IEnumerator MoveSin()
    {

        yield return new WaitForSeconds(0);
        fTime += Time.deltaTime * CurveSpeed;
        Vector3 vSin = new Vector3(Mathf.Sin(fTime) * 7, 0, 0);
        Vector3 vLin = new Vector3(0, -MoveSpeed, 0);
        transform.position += (vSin + vLin) * Time.deltaTime;
    }

}

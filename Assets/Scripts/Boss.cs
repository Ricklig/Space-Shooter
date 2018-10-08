using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public Transform zone1;
    public Transform zone2;
    public Transform killBox;

    public GameObject zone;
    public GameObject kb;

    float shotsFired = 2;
    float numberOfZones = 2;
    bool pause = true;

    const int startingHealth = 150;
    public int currentHealth = startingHealth;
    public RectTransform healthBar;


    // Use this for initialization
    void Start () {
        startPos = transform.position;
        moveTime = moveReset;
        StartCoroutine(zoneCreate());
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

        //shotsFired -= Time.deltaTime;
        if (shotsFired < 0)
        {
            Fire();
            shotsFired = 2;
        }


        if(currentHealth == 0)
        {

            GameObject.FindWithTag("GameController").GetComponent<GameManager>().endGame();
            Destroy(gameObject);
        }
        healthBar.sizeDelta = new Vector2(currentHealth,healthBar.sizeDelta.y);

    }
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.layer.Equals(8))
        {

            Destroy(col.gameObject);
            
        }

        else if (col.gameObject.layer.Equals(11))
        {

            col.gameObject.GetComponent<PlayerMove>().TakeDamage();
        }
    }

    void Fire()
    {
        Vector3 vectorToTarget = GameObject.FindWithTag("Player").GetComponent<Transform>().position - gameObject.transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle + 90, Vector3.forward);
        var bullet = (GameObject)Instantiate(bulletPrefab, gun.position, q);

    }

    IEnumerator zoneCreate()
    {

        yield return new WaitForSeconds(0);
        var z1 = (GameObject)Instantiate(zone, zone1.position, zone1.rotation);
        z1.transform.parent = transform;
        var z2 = (GameObject)Instantiate(zone, zone2.position, zone2.rotation);
        z2.transform.parent = transform;
        numberOfZones = 2;
    }
    IEnumerator killCreate()
    {

        yield return new WaitForSeconds(0);
        var box = (GameObject)Instantiate(kb, killBox.position, killBox.rotation);
        box.transform.parent = transform;
        yield return new WaitForSeconds(5);
        Destroy(box);
        StartCoroutine(zoneCreate());
    }


    public void zoneDestroy()
    {
        numberOfZones--;
        if (numberOfZones == 0)
        {
            StartCoroutine(killCreate());
        }
    }

    public void kbHit()
    {
        currentHealth -= 10;
    }
}

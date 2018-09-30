using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    private Rigidbody2D playerShip;
    public float xMin, xMax, yMin, yMax;
    public GameObject bulletPrefab;
    public Transform ygun;
    public Transform x1gun;
    public Transform x2gun;
    public Transform fgun;
    public Sprite ywing;
    public Sprite xwing;
    public Sprite falcon;

    public int level = 1;

    // Use this for initialization
    void Start () {
        playerShip = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

        if (level == 0)
        {
            endGame();
        }

        Move();

        if (Input.GetButtonDown("Fire"))
        {
            Fire();
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer.Equals(13))
        {
            Destroy(col.gameObject);
            TakeDamage();

        }

        else if (col.gameObject.layer.Equals(12))
        {
            Destroy(col.gameObject);
            LevelUp();
        }
    }

    void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime * 5.0f; ;
        float moveVertical = Input.GetAxis("Vertical") * Time.deltaTime * 5.0f; ;
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        playerShip.transform.Translate(movement);
        playerShip.position = new Vector3
            (
                Mathf.Clamp(playerShip.position.x, xMin, xMax),
                Mathf.Clamp(playerShip.position.y, yMin, yMax),
                0.0f
            );
    }

    void Fire()
    {
        if(level == 1)
        {
            var bullet = (GameObject)Instantiate(bulletPrefab, ygun.position, ygun.rotation);
        }
        else if(level == 2)
        {
            var xbullet = Instantiate(bulletPrefab, x1gun.position, x1gun.rotation);
            var xbullet1 = Instantiate(bulletPrefab, x2gun.position, x2gun.rotation);
        }
        else if (level == 3)
        {
            var fbullet = Instantiate(bulletPrefab, fgun.position, Quaternion.AngleAxis(25, Vector3.forward));
            var f1bullet = Instantiate(bulletPrefab, fgun.position, fgun.rotation);
            var f2bullet = Instantiate(bulletPrefab, fgun.position, Quaternion.AngleAxis(-25, Vector3.forward));
        }


    }

    public void TakeDamage()
    {
        level--;
        if (level > 0)
        {
            if (level == 2)
            {
                GetComponent<SpriteRenderer>().sprite = xwing;
            }
            else if (level == 1)
            {
                GetComponent<SpriteRenderer>().sprite = ywing;
            }         
        }
        else if (level == 0)
        {
            endGame();
        }
    }
    

    public void LevelUp()
    {
        if (level < 3)
        {
                level++;
            if(level == 2)
            {
                GetComponent<SpriteRenderer>().sprite = xwing;
            }
            else if (level == 3)
            {
                GetComponent<SpriteRenderer>().sprite = falcon;
            }
        }
    }

    void endGame()
    {
        Debug.Log("game over");
    }
}

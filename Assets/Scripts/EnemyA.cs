using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : MonoBehaviour {

    public GameObject explode;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 movement = new Vector3(0.0f, 3*Time.deltaTime, 0.0f);
        transform.Translate(movement); 
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.layer.Equals(8))
        {
            var boom = (GameObject)Instantiate(explode, transform.position, transform.rotation);
            Destroy(col.gameObject);
            gameObject.GetComponentInParent<EnemyAManager>().sendPos(gameObject.transform.position);
            GameObject.FindWithTag("GameController").GetComponent<GameManager>().updateScore(100);
            Destroy(gameObject);
        }

        else if (col.gameObject.layer.Equals(9))
        {
            gameObject.GetComponentInParent<EnemyAManager>().noBonus();
            Destroy(gameObject);
        }

        else if (col.gameObject.layer.Equals(11))
        {
            col.gameObject.GetComponent<PlayerMove>().TakeDamage();
            gameObject.GetComponentInParent<EnemyAManager>().noBonus();
            Destroy(gameObject);
        }
    }

}

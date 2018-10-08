using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killbox : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.layer.Equals(8))
        {

            Destroy(col.gameObject);
            gameObject.GetComponentInParent<Boss>().kbHit();
        }

        else if (col.gameObject.layer.Equals(11))
        {

            col.gameObject.GetComponent<PlayerMove>().TakeDamage();
        }
    }
}

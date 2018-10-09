using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killbox : MonoBehaviour {

    AudioSource hit;

    // Use this for initialization
    void Start()
    {

        hit = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.layer.Equals(8))
        {
            hit.Play();
            Destroy(col.gameObject);
            gameObject.GetComponentInParent<Boss>().kbHit();
        }

        else if (col.gameObject.layer.Equals(11))
        {

            col.gameObject.GetComponent<PlayerMove>().TakeDamage();
        }
    }
}

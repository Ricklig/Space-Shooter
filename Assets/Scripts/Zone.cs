using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour {

    float hp = 2;
    AudioSource hit;

    // Use this for initialization
    void Start () {
		hit = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		if (hp <= 0)
        {
            gameObject.GetComponentInParent<Boss>().zoneDestroy();
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.layer.Equals(8))
        {
            hit.Play();
            Destroy(col.gameObject);
            hp--;
        }

        else if (col.gameObject.layer.Equals(11))
        {

            col.gameObject.GetComponent<PlayerMove>().TakeDamage();
        }
    }
}

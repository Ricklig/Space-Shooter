using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour {
    

    void OnTriggerEnter2D(Collider2D col)
    {

         if (col.gameObject.layer.Equals(9))
        {
            Destroy(gameObject);

        }
    }
}

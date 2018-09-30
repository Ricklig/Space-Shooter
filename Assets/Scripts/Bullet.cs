using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float mSpeed;
    Rigidbody2D mRigidBody2D;
    Vector2 attack;
    Quaternion rotation;
    Vector2 angle;

    void Start()
    {
        // Must be done in Awake() because SetDirection() will be called early. Start() won't work.
        mRigidBody2D = GetComponent<Rigidbody2D>();

        // Set a default direction
        if (gameObject.layer.Equals(13))
        {
            attack = GameObject.FindWithTag("Player").GetComponent<Transform>().position - gameObject.transform.position;
            attack.Normalize();
            mRigidBody2D.velocity = attack * mSpeed;
        }


        if (gameObject.layer.Equals(8))
        {
            rotation = gameObject.transform.rotation;
            angle = rotation * Vector2.up ;
            mRigidBody2D.velocity = angle * mSpeed;
        }
           
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTimeOut : MonoBehaviour
{
    public int bounceNum;
    private int bounce = 0;

    void Update()
    {
        if (gameObject.transform.position.x < -9)
        {
            if (bounce < bounceNum)
            {
                gameObject.transform.position = new Vector3(9.0f, gameObject.transform.position.y, 0.0f);
                bounce++;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        if (gameObject.transform.position.x > 9)
        {
            if (bounce < bounceNum)
            {
                gameObject.transform.position = new Vector3(-9.0f, gameObject.transform.position.y, 0.0f);
                bounce++;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        if (gameObject.transform.position.y < -10)
        {
            if (bounce < bounceNum)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, -10, 0.0f);
                bounce++;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        if (gameObject.transform.position.y > 10)
        {
            if (bounce < bounceNum)
            {
                gameObject.transform.position = new Vector3( gameObject.transform.position.x, -10, 0.0f);
                bounce++;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
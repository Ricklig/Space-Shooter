using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

    public float scrollSpeed = 0;
    public float tileSizeZ;

    private Vector3 startPosition;

    private float startTime = 0;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (startTime > -3)
        {
            startTime -= Time.deltaTime;
            scrollSpeed -= Time.deltaTime * 2;
        }
        else if (startTime > -4)
        {
            startTime -= Time.deltaTime;
            scrollSpeed -= Time.deltaTime;
        }
        else if(startTime > -30)
        {
            startTime -= Time.deltaTime;
        }
        else if (startTime > -33)
        {
            startTime -= Time.deltaTime;
            if (scrollSpeed <= 0)
             {
                scrollSpeed += 0.002f;
            }
        }
        else if (startTime < -33)
        {
            scrollSpeed = 0;
            
        }

        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.up * newPosition;
    }

}

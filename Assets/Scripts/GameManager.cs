using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public float bossClock = 30.0f;
    public float aSetClock = 8.0f;
    public float bSetClock = 12.0f;

    public GameObject bossA;
    public Transform bossSpawn;

    public GameObject enemyA;
    public Transform[] spawnA;

    public GameObject enemyB;
    public Transform[] spawnB;

    public float aClock;
    public float bClock;

    // Use this for initialization
    void Start () {
        StartCoroutine(SpawnA());
        aClock = aSetClock;
        bClock = bSetClock;

    }
	
	// Update is called once per frame
	void Update () {

        if (bossClock > 0)
        {
            bossClock -= Time.deltaTime;
		    if (bossClock < 0)
            {
                var boss = (GameObject)Instantiate(bossA, bossSpawn.position, bossSpawn.rotation);
            }
        }


        if (aClock > 0 && bossClock > 0)
        {
            aClock -= Time.deltaTime;
            if (aClock < 0)
            {
                StartCoroutine(SpawnA());
                aClock = aSetClock;
            }
        }

        if (bClock > 0 && bossClock > 0)
        {
            bClock -= Time.deltaTime;
            if (bClock < 0)
            {
                StartCoroutine(SpawnB());
                bClock = bSetClock;
            }
        }

    }
    IEnumerator SpawnA()
    {
        yield return new WaitForSeconds(0);
        int spawnPointIndex = Random.Range(0, spawnA.Length);
        var enemy = (GameObject)Instantiate(enemyA, spawnA[spawnPointIndex].position, spawnA[spawnPointIndex].rotation);
    }
    IEnumerator SpawnB()
    {
        yield return new WaitForSeconds(0);
        int spawnPointIndex = Random.Range(0, spawnB.Length);
        var enemy = (GameObject)Instantiate(enemyB, spawnB[spawnPointIndex].position, spawnB[spawnPointIndex].rotation);
    }

}
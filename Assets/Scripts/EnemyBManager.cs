using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBManager : MonoBehaviour {

    public GameObject enemyPrefab;

    public int alive = 5;
    bool bns = true;
    bool spawnOver = false;
    public GameObject bonusDrop;

    Vector3 position;

    // Use this for initialization
    void Start () {
        
        StartCoroutine(Spawn());
    }

    public void noBonus()
    {
        bns = false;
    }

    public void sendPos(Vector3 pos)
    {
        position = pos;
    }

    void Update()
    {
        if (spawnOver)
        {
            alive = gameObject.transform.childCount;
        }
        
        if (alive == 0)
        {
            if (bns)
            {
                var bonus = (GameObject)Instantiate(bonusDrop, position, gameObject.transform.rotation);
                GameObject.FindWithTag("GameController").GetComponent<GameManager>().mulScore();
            }  
            Destroy(gameObject);
        }

    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(0);
        var enemy = (GameObject)Instantiate(enemyPrefab, gameObject.transform.position, gameObject.transform.rotation);
        enemy.transform.parent = transform;
        yield return new WaitForSeconds(.5f);
        var enemy1 = (GameObject)Instantiate(enemyPrefab, gameObject.transform.position, gameObject.transform.rotation);
        enemy1.transform.parent = transform;
        yield return new WaitForSeconds(.5f);
        var enemy2 = (GameObject)Instantiate(enemyPrefab, gameObject.transform.position, gameObject.transform.rotation);
        enemy2.transform.parent = transform;
        yield return new WaitForSeconds(.5f);
        var enemy3 = (GameObject)Instantiate(enemyPrefab, gameObject.transform.position, gameObject.transform.rotation);
        enemy3.transform.parent = transform;
        yield return new WaitForSeconds(.5f);
        var enemy4 = (GameObject)Instantiate(enemyPrefab, gameObject.transform.position, gameObject.transform.rotation);
        enemy4.transform.parent = transform;
        spawnOver = true;


    }




}

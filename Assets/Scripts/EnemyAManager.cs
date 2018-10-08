using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAManager : MonoBehaviour {

    public int alive = 5;

    bool bns = true;

    public GameObject bonusDrop;

    Vector3 position;

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
        alive = gameObject.transform.childCount;
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



}

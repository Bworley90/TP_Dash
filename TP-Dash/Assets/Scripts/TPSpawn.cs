using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSpawn : MonoBehaviour
{
    private GameManager gm;
    private float spawnChancePercentage;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        spawnChancePercentage = gm.difficulty;
        SpawnTP();
    }



    private void SpawnTP()
    {
        if(gm.tpSpawned < gm.tpTotal)
        {
            print(transform.childCount);
            for (int i = 0; i < transform.childCount; i++)
            {
                int randomNumber = Random.Range(0, 100);
                if (randomNumber < spawnChancePercentage)
                {
                    Instantiate(gm.tp, transform.GetChild(i).transform);
                    gm.tpSpawned++;
                }
                else
                {
                   
                }
            }
        }
        
    }

}

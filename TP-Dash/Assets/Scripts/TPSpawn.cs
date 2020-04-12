using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSpawn : MonoBehaviour
{
    public List<Transform> tpSpawnPoints = new List<Transform>();
    public GameObject tp;
    private void Start()
    {
        SpawnTP(); 
    }



    public void SpawnTP()
    {
        if(GameManager.gm.tpSpawned < GameManager.gm.tpTotal)
        {
            foreach (Transform spawn in tpSpawnPoints)
            {
                float rand = Random.Range(1, 100);
                if (rand <= 33)
                {
                    Instantiate(tp, spawn);
                    GameManager.gm.tpSpawned++;
                }

            }
        }
       
    }

}

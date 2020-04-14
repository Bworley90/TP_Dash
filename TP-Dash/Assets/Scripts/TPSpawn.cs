using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSpawn : MonoBehaviour
{
    public Transform[] spawnPoints;

    public void SpawnTP()
    {
        foreach(Transform point in spawnPoints)
        {
            int rand = Random.Range(0, 6);
            if(GameManager.gm.tpSpawned < GameManager.gm.tpTotal)
            {
                if (rand <= 1)
                {
                    try
                    {
                        Instantiate(GameManager.gm.tp, point);
                        GameManager.gm.tpSpawned++;
                    }
                    catch
                    {
                        print("Error in Creating TP " + point.transform.name);
                    }

                }
            }
            
            
        }
    }
    

}

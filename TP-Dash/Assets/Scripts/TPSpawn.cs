using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSpawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    List<Transform> usedPoints = new List<Transform>();

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
                        if(!usedPoints.Contains(point))
                        {
                            Instantiate(StaticVariables.statics.tp, point);
                            GameManager.gm.tpSpawned++;
                            usedPoints.Add(point);
                        }
                        else
                        {
                            print("There was TP there already");
                        }
                        
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

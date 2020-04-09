using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{

    [Header("TP Tracking")]
    public int tpCollected;
    public int tpTotal;
    public int tpSpawned;
    [Range(1,100)]
    [Tooltip("Percent to Spawn TP per node")]
    public int difficulty;
    public GameObject tp;
    public int numberOfTPCheckedOut;
    public GameObject[] spawnPoints;

    [Header("Checkout")]
    [Range(0, 5)]
    public float timeBetweenTpSold;
    
    

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        StartWave();
        BakeNavMesh();
    }

    private void StartWave()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        foreach(GameObject rg in spawnPoints)
        {
            if(rg.GetComponent<LayoutRoomGenerator>() != null)
            {
                rg.GetComponent<LayoutRoomGenerator>().ChooseARoom();
            }
        }
    }

    public void BakeNavMesh()
    {
        GetComponent<NavMeshSurface>().BuildNavMesh();
    }


}

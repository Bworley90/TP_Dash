using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    private bool sceneLoaded = false;

    [Header("TP Tracking")]
    public int tpCollected;
    public int tpTotal;
    public int tpSpawned;
    [Range(1,100)]
    [Tooltip("Percent to Spawn TP per node")]
    public int difficulty;
    public GameObject tp;
    public int numberOfTPCheckedOut;
    public List<GameObject> roomsSpawnPoints = new List<GameObject>();

    [Header("Checkout")]
    [Range(0, 5)]
    public float timeBetweenTpSold;

    [Header("Room Tracking")]
    public List<GameObject> roomsSpawned = new List<GameObject>();

    private void Awake()
    {
        if (gm != null && gm != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            gm = this;
            DontDestroyOnLoad(gameObject);
        }
    } // Singleton 

    private void StartWave()
    {
        roomsSpawnPoints.AddRange(GameObject.FindGameObjectsWithTag("SpawnPoint"));
        foreach(GameObject rg in roomsSpawnPoints)
        {
            if(rg.GetComponent<LayoutRoomGenerator>() != null)
            {
                rg.GetComponent<LayoutRoomGenerator>().ChooseARoom();
            }
        }
        foreach (GameObject tpSpawns in roomsSpawnPoints)
        {
            if(GetComponent<TPSpawn>() != null)
            {
                tpSpawns.GetComponent<TPSpawn>().SpawnTP();
            }
            else
            {
                print(tpSpawns.transform.name + " does not have a TP Spawn on the prefab");
            }
        }

    }

    public void BakeNavMesh()
    {
        GetComponent<NavMeshSurface>().BuildNavMesh();
    }

    private void GenerateNewLevel()
    {
        SceneManager.LoadScene(1); // Load Loading Screen;
        roomsSpawned.Clear(); // ClearOut Room Prefabs
        roomsSpawnPoints.Clear(); // Removing Prefabs list
        GetComponent<NavMeshSurface>().RemoveData();
        ResetScores();
        sceneLoaded = false;

    }

    private void Update()
    {
        if(!sceneLoaded && SceneManager.GetActiveScene().buildIndex == 2)
        {
            sceneLoaded = true;
            StartWave();
            BakeNavMesh();
            
        }
        if (Input.GetButtonDown("Jump"))
        {
            GenerateNewLevel();
        }
    }

    private void ResetScores()
    {
        numberOfTPCheckedOut = 0;
        tpCollected = 0;
    }
}

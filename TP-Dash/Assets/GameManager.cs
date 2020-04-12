using System.Collections;
using System.Collections.Generic;
using System;
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
    public int difficulty;
    public GameObject tp;
    public int numberOfTPCheckedOut;

    [Header("Checkout")]
    [Range(0, 5)]
    public float timeBetweenTpSold;

    [Header("Room Tracking")]
    public List<GameObject> roomsCreated = new List<GameObject>();


    // Leavers
    List<GameObject> roomsSpawnPoints = new List<GameObject>();




    // New 

    public List<GameObject> roomGenerators = new List<GameObject>();

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
                rg.GetComponent<LayoutRoomGenerator>().CreateRoom();  
            }
        }
        

    }
    private void GenerateNewLevel()
    {
        SceneManager.LoadScene(1); // Load Loading Screen;
        roomsCreated.Clear(); // ClearOut Room Prefabs
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
            LevelGeneration();
        }
        if (Input.GetButtonDown("Jump"))
        {
            LevelGeneration();
        }
    }

    private void ResetScores()
    {
        numberOfTPCheckedOut = 0;
        tpCollected = 0;
        difficulty = 1;
    }


    private void LevelGeneration()
    {
        ResetScores(); // Reset Varibles for TP

        ClearList(roomsCreated, true); // Delete all prefabs of rooms;

        ClearList(roomGenerators, false); ; // Deletes all spawnpoints

        GetComponent<NavMeshSurface>().RemoveData();// Remove old NavMesh

        roomGenerators.AddRange(GameObject.FindGameObjectsWithTag("SpawnPoint"));  // Gather all spawnpoints

        SpawnRoomPrefab();// Spawns the rooms on the main spawn points

        GetComponent<NavMeshSurface>().BuildNavMesh(); // Bake a navmesh to created rooms

        // LayoutRoomGenerator is giving back this list of prefab room names
        // Take these and check for a script to spawn TP in that room
        RandomizeTPInPrefabs();
    }

    private void SpawnRoomPrefab()
    {
        foreach (GameObject spawnpoint in roomGenerators) // Spawn the rooms from the LayoutRoomGenerator function CreateRoom
        {
            try
            {
                spawnpoint.GetComponentInChildren<LayoutRoomGenerator>().CreateRoom(); // Spawn a room at the spawnpoint
            }
            catch
            {
                print(spawnpoint.transform.name + " Is missing a LayoutRoomGenerator Script"); // Check for missing script
            }
        }
    }

    private void RandomizeTPInPrefabs()
    {
        while (tpSpawned < tpTotal)
        {
            foreach (GameObject room in roomsCreated)
            {
                if (tpSpawned < tpTotal)
                {
                    try
                    {
                        room.GetComponent<TPSpawn>().SpawnTP();
                    }
                    catch
                    {
                        print(room.transform.name + " is missing the TP spawn script");
                    }
                }

            }
        }

    }

    private void ClearList(List<GameObject> listToClear, bool destroyObject)
    {
        if(destroyObject)
        {
            foreach (GameObject game in listToClear)
            {
                Destroy(game);
            }
            listToClear.Clear();
            listToClear.TrimExcess();
            listToClear.Capacity = 0;
        }
        else
        {
            listToClear.Clear();
            listToClear.TrimExcess();
            listToClear.Capacity = 0;
        }
        
    }
}

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
    public GameObject[] spawnPoints;

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

    private void GenerateNewLevel()
    {
        SceneManager.LoadScene(1); // Load Loading Screen;
        roomsSpawned.Clear();
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
    }
}

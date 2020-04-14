using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public enum GameState
    {
        waitingToStart,
        started,
        waveComplete,
        gameOver,
        mainMenu,
        loading
    }

    public GameState gameState;

    private bool levelLoaded = false;

    [Header("TP Tracking")]
    public int tpCollected;
    public int tpTotal;
    public int tpSpawned;
    public int difficulty;
    public GameObject tp;
    public int numberOfTPCheckedOut;

    [Header("Time")]
    public float timeleft;
    public int maxTime;
    public Text timerText;

    [Header("Checkout")]
    [Range(0, 5)]
    public float timeBetweenTpSold;

    [Header("Room Tracking")]
    public List<GameObject> roomsCreated = new List<GameObject>();
    public List<GameObject> roomGenerators = new List<GameObject>();


    //UI
    private Animator UIanim;
    private float startingTimer = 5;


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

    private void Update()
    {
        if (gameState == GameState.mainMenu)
        {
            ResetScores();
        }

        else if (gameState == GameState.loading)
        {

        }
        else if (gameState == GameState.waitingToStart)
        {
            LevelGeneration();
            TimeToStart();
        }
        else if(gameState == GameState.started)
        {
            TimeCountdown();
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                gameState = GameState.mainMenu;
            }
        }
        else if (gameState == GameState.waveComplete)
        {

        }
        else if (gameState == GameState.gameOver)
        {
            GameOver();
        }
        
        
    }

    public void ResetScores()
    {
        numberOfTPCheckedOut = 0;
        tpCollected = 0;
        difficulty = 1;
        timeleft = maxTime;
        levelLoaded = false;
        startingTimer = 5;
        tpSpawned = 0;
    }


    private void LevelGeneration()
    {
        if(!levelLoaded)
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
            levelLoaded = true;
        }
        
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

    private void TimeCountdown()
    {
        timeleft -= Time.deltaTime * 1;
        if(timeleft <= 0)
        {
            gameState = GameState.gameOver;
        }
    }

    private void TimeToStart()
    {
        GameObject gameUI = GameObject.FindGameObjectWithTag("InGameUI");
        gameUI.GetComponent<InGameButtons>().countdownText.enabled = true;
        startingTimer -= Time.deltaTime * 1;
        gameUI.GetComponent<InGameButtons>().countdownText.text = 
            Mathf.RoundToInt(startingTimer).ToString(); // Update UI
        if(startingTimer <= 0)
        {
            gameState = GameState.started;
            gameUI.GetComponent<InGameButtons>().countdownText.enabled = false;

        }
    }

    private void GameOver()
    {
        if(gameState == GameState.gameOver)
        {
            UIanim = GameObject.FindGameObjectWithTag("InGameUI").GetComponent<Animator>();
            UIanim.SetBool("gameOver", true);

        }
    }

    public void LoadSceneAsync()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(2);
        while(!async.isDone)
        {
            yield return null;
        }
        gameState = GameState.waitingToStart;
    }

}

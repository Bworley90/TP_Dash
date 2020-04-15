using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    

    public enum State
    {
        generateLevel,
        countdown,
        gameStarted,
        gameOver,
        nextLevel,
    }

    public State state;

    [Header("UI")]
    [SerializeField]
    private GameObject startCountdownTimerText;
    private Animator uIanim;

    [Header("Time")]
    [Range(0, 10)]
    [Tooltip("This number adjusts the countdown timer at the start of the game")]
    [SerializeField]
    private float startCountdownLength;

    


    private bool levelLoaded = false;

    [Header("TP Tracking")]
    public int tpCollected;
    public int tpTotal;
    public int tpSpawned;
    public int numberOfTPCheckedOut;
    public bool checkingOut;

    [Header("Time")]
    public float timeleft;
    public float maxTime;
    public Text timerText;

    [Header("Checkout")]
    [Range(0, 5)]
    public float timeBetweenTpSold;

    [Header("Room Tracking")]
    public List<GameObject> prefabRooms = new List<GameObject>();
    public List<GameObject> roomGenerators = new List<GameObject>();

    [Header("BuyMenu")]
    public int cartSpeedIncrease;
    public int luckyStrikeAmount;
    public int discoverDistanceAmount;
    public int levelDurationIncreaseAmount;



    private void Start()
    {
        state = State.generateLevel;
        uIanim = GameObject.FindGameObjectWithTag("InGameUI").GetComponent<Animator>();
        gm = this;
        maxTime = StaticVariables.statics.levelDuration;
        timeleft = maxTime;
        
    }

    private void Update()
    {
        if(state == State.countdown)
        {
            StartCountdown();
        }
        else if(state == State.generateLevel)
        {
            GenerateWorld();
        }
        else if(state == State.gameStarted)
        {
            LevelDuration();
            CheckForWinCondition();
        }
        tpTotal = StaticVariables.statics.difficulty + 4;
    }



    private void CheckForWinCondition()
    {
        if(numberOfTPCheckedOut >= StaticVariables.statics.tpNeeded && tpCollected <= 0)
        {
            if(numberOfTPCheckedOut > StaticVariables.statics.tpNeeded)
            {
                StaticVariables.statics.tpMoney = (numberOfTPCheckedOut - StaticVariables.statics.tpNeeded);
            }
            //Animation here
            uIanim.SetTrigger("roundEnd");
            state = State.nextLevel;
        }
    }

    private void SpawnRoomPrefab()
    {
        foreach (GameObject spawnpoint in roomGenerators) // Spawn the rooms from the LayoutRoomGenerator function CreateRoom
        {
            try
            {
                spawnpoint.GetComponent<LayoutRoomGenerator>().CreateRoom(); // Spawn a room at the spawnpoint
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
            foreach (GameObject room in prefabRooms)
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

    private void StartCountdown()
    {
        startCountdownTimerText.GetComponent<startCountdownTimer>().CountdownTimer(startCountdownLength);
        startCountdownLength -= Time.deltaTime;
        if(startCountdownLength <= 0)
        {
            state = State.gameStarted;
            uIanim.SetTrigger("gameStarted");
        }
    }

    private void GenerateWorld()
    {
        roomGenerators.AddRange(GameObject.FindGameObjectsWithTag("SpawnPoint"));  // Gather all spawnpoints

        SpawnRoomPrefab();// Spawns the rooms on the main spawn points

        GetComponent<NavMeshSurface>().BuildNavMesh(); // Bake a navmesh to created rooms

        // LayoutRoomGenerator is giving back this list of prefab room names
        // Take these and check for a script to spawn TP in that room
        
        RandomizeTPInPrefabs();

        uIanim.SetTrigger("generatedLevel");
        state = State.countdown;
    }

    private void LevelDuration()
    {
        if(state == State.gameStarted && !checkingOut)
        {
            timeleft -= Time.deltaTime;
            if(timeleft <= 0)
            {
                uIanim.SetTrigger("roundEnd");
                state = State.gameOver;
                
            }
        }
    }


    private void ClearList(List<GameObject> listToClear, bool destroyObject)
    {
        if (destroyObject)
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

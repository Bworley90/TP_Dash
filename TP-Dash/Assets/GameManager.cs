using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int tpCollected;
    public int tpTotal;
    public int tpSpawned;
    [Range(1,100)]
    [Tooltip("Percent to Spawn TP per node")]
    public int difficulty;
    public GameObject tp;
    

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }


}

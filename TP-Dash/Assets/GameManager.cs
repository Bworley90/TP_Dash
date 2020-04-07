using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [Header("Checkout")]
    [Range(0, 5)]
    public float timeBetweenTpSold;
    
    

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }


}

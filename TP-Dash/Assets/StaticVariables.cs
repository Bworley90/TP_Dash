using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticVariables : MonoBehaviour
{
    public static StaticVariables statics;

    private void Awake()
    {
        if(statics != null)
        {
            Destroy(gameObject);
        }
        else
        {
            statics = this;
            DontDestroyOnLoad(gameObject);
        }

    }


    [Header("Variables")]
    public int difficulty;
    public int tpNeeded;
    public float cartSpeed;
    public float levelDuration;
    public float discoverDistance;
    public float luckyStrike;
    public float tpMoney;


    [Header("GameObjects")]
    public GameObject tp;


    [Header("Original Settings")]
    private int originalDifficulty;
    private int originalTpNeeded;
    private float cartSpeedOriginal;
    private float levelDurationOriginal;
    private float discoverDistanceOriginal;
    private float luckyStrikeOriginal;
    private float tpMoneyOriginal;

    private void Start()
    {
        originalDifficulty = difficulty;
        originalTpNeeded = tpNeeded;
        cartSpeedOriginal = cartSpeed;
        levelDurationOriginal = levelDuration;
        discoverDistanceOriginal = discoverDistance;
        luckyStrikeOriginal = luckyStrike;
        tpMoneyOriginal = tpMoney;
    }

    public void RestoreSettings()
    {
        tpNeeded = originalTpNeeded;
        difficulty = originalDifficulty;
        cartSpeed = cartSpeedOriginal;
        levelDuration = levelDurationOriginal;
        luckyStrike = discoverDistanceOriginal;
        discoverDistance = discoverDistanceOriginal;
        tpMoney = tpMoneyOriginal;
    }
}

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

    [Header("GameObjects")]
    public GameObject tp;


    [Header("Original Settings")]
    private int originalDifficulty;
    private int originalTpNeeded;

    private void Start()
    {
        originalDifficulty = difficulty;
        originalTpNeeded = tpNeeded;
    }

    public void RestoreSettings()
    {
        tpNeeded = originalTpNeeded;
        difficulty = originalDifficulty;
    }
}

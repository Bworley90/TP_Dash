using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimerCountdown : MonoBehaviour
{
    private int maxTime;
    private float timeleft;

    private void Update()
    {
        maxTime = GameManager.gm.maxTime;
        timeleft = GameManager.gm.timeleft;
        if(GameManager.gm.gameState == GameManager.GameState.started)
        {
            GetComponent<Text>().text = ("Time Left : " + Mathf.RoundToInt(timeleft).ToString());
        }
    }
}

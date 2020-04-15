using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimerCountdown : MonoBehaviour
{

    private void Update()
    {
        if(GameManager.gm.state == GameManager.State.gameStarted)
        {
            GetComponent<Text>().text = ("TIME LEFT: " + Mathf.RoundToInt(GameManager.gm.timeleft).ToString());
        }
        else if(GameManager.gm.state == GameManager.State.gameOver)
        {
            GetComponent<Text>().text = "GAME OVER";
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameButtons : MonoBehaviour
{
    public Text countdownText;
    public void Retry()
    {
        //GetComponent<Animator>().SetBool("gameOver", false);
        //GameManager.gm.state = GameManager.GameState.waitingToStart;
        //GameManager.gm.ResetScores();
    }

    public void Quit()
    {
        //GameManager.gm.gameState = GameManager.GameState.mainMenu;
        //SceneManager.LoadScene(0);
        //GameManager.gm.ResetScores();
        

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameButtons : MonoBehaviour
{
    public void Retry()
    {
        GetComponent<Animator>().SetBool("gameOver", false);
        GameManager.gm.gameState = GameManager.GameState.waitingToStart;
        GetComponent<Animator>().SetTrigger("backToStart");
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
        GameManager.gm.gameState = GameManager.GameState.mainMenu;

    }
}

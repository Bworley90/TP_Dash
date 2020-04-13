using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void GoToNewScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
        GameManager.gm.gameState = GameManager.GameState.loading;
    }

    public void OptionsButton()
    {
        // DO some kinda of animations for options menu
    }
}

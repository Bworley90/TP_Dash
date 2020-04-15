using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void GoToNewScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void OptionsButton()
    {
        // DO some kinda of animations for options menu
    }
}

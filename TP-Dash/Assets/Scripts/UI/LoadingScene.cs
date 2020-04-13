using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public Button okButton;
    public Text okButtonText;
    private bool ready = false;

    private void Update()
    {
        if(!ready)
        {
            okButton.interactable = false;
            okButtonText.text = "Loading..";
            StartCoroutine(FakeLoad());
        }
        else
        {
            SceneManager.LoadScene(2);
            GameManager.gm.gameState = GameManager.GameState.waitingToStart;
        }
    }

    IEnumerator FakeLoad()
    {
        yield return new WaitForSeconds(4f);
        ready = true;
    }



}



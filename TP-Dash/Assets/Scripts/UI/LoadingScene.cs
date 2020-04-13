using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    private bool loadingScene = false;

    [SerializeField]
    private int sceneNumber;
    [SerializeField]
    private Text loadingText;
    AsyncOperation async;
    [SerializeField]
    Button okButton;


    private void Update()
    {
        if(!loadingScene)
        {
            loadingScene = true;
            loadingText.text = "Loading...";
            StartCoroutine(LoadNewScene());
        }
        if(loadingScene)
        {
            if(!async.isDone)
            {
                okButton.interactable = false;
                loadingText.text = "Loading";
            }
            else
            {
                okButton.interactable = true;
                loadingText.text = "Ok, Got it!";
            }
        }
    }

    IEnumerator LoadNewScene()
    {
        async = SceneManager.LoadSceneAsync(sceneNumber);

        while(!async.isDone)
        {
            yield return null;
        }
    }


}

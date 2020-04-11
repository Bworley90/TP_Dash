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
            loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));
        }
    }

    IEnumerator LoadNewScene()
    {
        yield return new WaitForSeconds(3f);
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneNumber);

        while(!async.isDone)
        {
            yield return null;
        }
    }


}

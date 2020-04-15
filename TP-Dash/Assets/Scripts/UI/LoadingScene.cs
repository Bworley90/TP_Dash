using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public void OkButton(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }



}



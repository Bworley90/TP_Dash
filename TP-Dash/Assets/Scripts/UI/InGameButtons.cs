using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameButtons : MonoBehaviour
{
    public void Retry()
    {
        StaticVariables.statics.RestoreSettings();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
 
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoundEndMenu : MonoBehaviour
{
    public Text timeLeftText;
    public Text tpCollectedText;
    public Text tpNeededText;
    public Text menuStatusText;
    public GameObject continueButton;
    public GameObject gameOverButton;



    private void Update()
    {
        timeLeftText.text = GameManager.gm.timeleft.ToString();
        tpCollectedText.text = GameManager.gm.tpCollected.ToString();
        tpNeededText.text = StaticVariables.statics.tpNeeded.ToString();
        if(GameManager.gm.state == GameManager.State.gameOver)
        {
            continueButton.SetActive(false);
            gameOverButton.SetActive(true);
            tpCollectedText.text = GameManager.gm.tpCollected.ToString();
            menuStatusText.text = "Game Over";
        }
        if(GameManager.gm.state == GameManager.State.nextLevel)
        {
            continueButton.SetActive(true);
            gameOverButton.SetActive(false);
            tpCollectedText.text = GameManager.gm.numberOfTPCheckedOut.ToString();
            menuStatusText.text = "Level Complete";
        }
    }

    public void levelCompleteContinue()
    {
        StaticVariables.statics.tpNeeded += StaticVariables.statics.difficulty;
        SceneManager.LoadScene(2);
    }

    public void gameOverContinue()
    {
        GameObject.FindGameObjectWithTag("InGameUI").GetComponent<Animator>().SetTrigger("gameOver");
    }

}

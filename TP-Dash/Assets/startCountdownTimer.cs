using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startCountdownTimer : MonoBehaviour
{
    public Text text;
    private void Start()
    {
        text = GetComponent<Text>();
    }

    public void CountdownTimer(float timeLeft)
    {
        text.text = Mathf.RoundToInt(timeLeft).ToString();
    }

}

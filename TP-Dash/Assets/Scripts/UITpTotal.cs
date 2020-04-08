using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITpTotal : MonoBehaviour
{

    private Text text;
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = gm.numberOfTPCheckedOut.ToString();
    }
}

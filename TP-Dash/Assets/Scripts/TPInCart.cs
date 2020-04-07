using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPInCart : MonoBehaviour
{
    private GameManager gm;
    public GameObject[] tp;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < tp.Length; i++)
        {
            
            if(i <= gm.tpCollected -1)
            {
                tp[i].SetActive(true);
            }
            
        }
        for (int i = 0; i < tp.Length; i++)
        {
            if( i > gm.tpCollected -1)
            {
                tp[i].SetActive(false);
            }
        }
    }
}

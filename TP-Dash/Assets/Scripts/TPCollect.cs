using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPCollect : MonoBehaviour
{
    private GameManager gm;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            // Play animation for destruction
            gm.tpCollected++;
            Destroy(gameObject);
        }
    }
}

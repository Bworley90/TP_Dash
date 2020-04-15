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
        int rand = Random.Range(0, 101);
        if(other.CompareTag("Player"))
        {
            // Play animation for destruction
            other.GetComponentInChildren<ParticleSystem>().Play();
            other.GetComponent<AudioSource>().PlayOneShot(GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().tpCollectNoise);
            gm.tpCollected++;
            if(rand <= StaticVariables.statics.luckyStrike)
            {
                gm.tpCollected++;
            }
            Destroy(gameObject);
        }
    }
}

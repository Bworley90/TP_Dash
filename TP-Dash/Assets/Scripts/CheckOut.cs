using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOut : MonoBehaviour
{
    private GameManager gm;
    private bool checkOutWait = false;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (gm.tpCollected > 0 && !checkOutWait) // If we have TP collected
            {
                checkOutWait = true;
                StartCoroutine(TakeTP());
                other.GetComponent<AudioSource>().PlayOneShot
                    (GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().checkOutNoise);
            }
        }
        
    }


    private IEnumerator TakeTP()
    {
        gm.tpCollected--;
        // Play some kinda animation for TP leaving cart
        // Maybe sound here;
        gm.numberOfTPCheckedOut++;
        yield return new WaitForSeconds(gm.timeBetweenTpSold);
        checkOutWait = false;
    }
}

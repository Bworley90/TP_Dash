using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOut : MonoBehaviour
{
    private GameManager gm;
    private bool checkOutWait;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(gm.tpCollected > 0 && !checkOutWait) // If we have TP collected
        {
            checkOutWait = true;
            //CouRotuine
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckoutArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameManager.gm.checkingOut = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameManager.gm.checkingOut = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocker : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("SpawnPoint"))
        {
            
        }
    }
}

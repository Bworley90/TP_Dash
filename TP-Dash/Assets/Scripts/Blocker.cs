using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocker : MonoBehaviour
{
    public bool exists = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<RoomGenerator>() != null)
        {
            if(other.GetComponent<RoomGenerator>().openDirection == 0)
            {
                if(other.GetComponent<Blocker>() != null)
                {
                   if(other.GetComponent<Blocker>().exists == true)
                    {
                        Destroy(other.transform.parent.gameObject);
                    }
                }
            }
        }
    }

    
}

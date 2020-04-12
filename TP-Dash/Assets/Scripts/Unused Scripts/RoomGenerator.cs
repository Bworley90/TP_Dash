using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public int openDirection;
    private RoomLayouts rm;
    public bool roomExists = false;
    public bool roomSpawned = false;
    public bool blockerSpawned = false;
    


    private void Start()
    {
        rm = GameObject.FindGameObjectWithTag("RoomLayout").GetComponent<RoomLayouts>();
        Invoke("RoomSpawn", 1f);
    }





    private void RoomSpawn()
    {
        if(!roomExists)
        {
            if (openDirection == 1)
            {
                Instantiate(rm.bottomOpen[Random.Range(0, rm.bottomOpen.Length)], transform);
                roomSpawned = true;
            }
            else if (openDirection == 2)
            {
                Instantiate(rm.leftOpen[Random.Range(0, rm.leftOpen.Length)], transform);
                roomSpawned = true;
            }
            else if (openDirection == 3)
            {
                Instantiate(rm.topOpen[Random.Range(0, rm.topOpen.Length)], transform);
                roomSpawned = true;
            }
            else if (openDirection == 4)
            {
                Instantiate(rm.rightOpen[Random.Range(0, rm.rightOpen.Length)], transform);
                roomSpawned = true;
            }
        }
        
    }


  
    
}

    




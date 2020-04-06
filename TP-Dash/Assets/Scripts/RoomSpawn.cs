using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawn : MonoBehaviour
{
    public int openDirection;
    // 1 top
    // 2 right
    // 3 bottom
    // 4 left

    private RoomLayouts layout;



    private int rand;
    public bool spawned;

    private void Start()
    {
        layout = GameObject.FindGameObjectWithTag("RoomLayout").GetComponent<RoomLayouts>();
        Invoke("Spawn", 1f);
    }


    private void Spawn()
    {
        if (!spawned)
        {
            if (openDirection == 1) // Spawn room with door on top
            {
                Instantiate(layout.topOpen[Random.Range(0, layout.topOpen.Length)], transform);
            }
            else if (openDirection == 2) // Spawn room with door on right
            {
                Instantiate(layout.rightOpen[Random.Range(0, layout.rightOpen.Length)], transform);
            }
            else if (openDirection == 3) // Spawn room with door on bottom
            {
                Instantiate(layout.bottomOpen[Random.Range(0, layout.bottomOpen.Length)], transform);
            }
            else if (openDirection == 4) // Spawn room with door on Left
            {
                Instantiate(layout.leftOpen[Random.Range(0, layout.leftOpen.Length)], transform);
            }
        }
        spawned = true;

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "SpawnPoint")
        {
            
                if (other.gameObject.GetComponent<RoomSpawn>().spawned == false && spawned == false)
                {
                    Instantiate(layout.blocker, transform);
                    Destroy(gameObject);
                }
            
            else
            {
                print(other.name);
            }

            spawned = true;
        }
    }


    private void Test(Collider other)
    {
        /*if (other.gameObject.tag == "SpawnPoint")
       {
           if(other.gameObject.GetComponent<RoomSpawn>().spawned == false && spawned == false)
           {
               Instantiate(layout.blocker, transform);
               Destroy(gameObject);
           }
           spawned = true;
       } */

    }
}

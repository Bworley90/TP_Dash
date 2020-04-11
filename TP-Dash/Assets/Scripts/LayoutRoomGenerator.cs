using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutRoomGenerator : MonoBehaviour
{
    private RoomLayoutPrefabs rlp;
    private GameManager gm;

    public enum RoomType {Side, Corner, Middle, Starts};
    public RoomType roomType;


    private void Awake()
    {
        rlp = GameObject.FindGameObjectWithTag("RoomLayout").GetComponent<RoomLayoutPrefabs>();
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    public void ChooseARoom()
    {
        GameObject room;
        if(roomType == RoomType.Side)
        {
            room = Instantiate(rlp.sides[Random.Range(0, rlp.sides.Length)], transform);
            gm.roomsSpawned.Add(room);
        }
        else if (roomType == RoomType.Corner)
        {
            room = Instantiate(rlp.corners[Random.Range(0, rlp.corners.Length)], transform);
            gm.roomsSpawned.Add(room);
        }
        else if (roomType == RoomType.Middle)
        {
            room = Instantiate(rlp.middles[Random.Range(0, rlp.middles.Length)], transform);
            gm.roomsSpawned.Add(room);
        }
        else if(roomType == RoomType.Starts)
        {
            room = Instantiate(rlp.starts[Random.Range(0, rlp.starts.Length)], transform);
            gm.roomsSpawned.Add(room);
        }
    }

   
}

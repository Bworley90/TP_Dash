using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutRoomGenerator : MonoBehaviour
{
    private RoomLayoutPrefabs rlp;

    public enum RoomType {Side, Corner, Middle, Starts};
    public RoomType roomType;


    private void Awake()
    {
        rlp = GameObject.FindGameObjectWithTag("RoomLayout").GetComponent<RoomLayoutPrefabs>();
    }

    public void CreateRoom()
    {
        GameObject room;
        if(roomType == RoomType.Side)
        {
            room = Instantiate(rlp.sides[Random.Range(0, rlp.sides.Length)], transform);
            GameManager.gm.roomsCreated.Add(room);
        }
        else if (roomType == RoomType.Corner)
        {
            room = Instantiate(rlp.corners[Random.Range(0, rlp.corners.Length)], transform);
            GameManager.gm.roomsCreated.Add(room);
        }
        else if (roomType == RoomType.Middle)
        {
            room = Instantiate(rlp.middles[Random.Range(0, rlp.middles.Length)], transform);
            GameManager.gm.roomsCreated.Add(room);
        }
        else if(roomType == RoomType.Starts)
        {
            room = Instantiate(rlp.starts[Random.Range(0, rlp.starts.Length)], transform);
            GameManager.gm.roomsCreated.Add(room);
        }
    }

   
}

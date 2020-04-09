using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LayoutRoomGenerator : MonoBehaviour
{
    private RoomLayoutPrefabs rlp;

    public enum RoomType {Side, Corner, Middle};
    public RoomType roomType;


    private void Awake()
    {
        rlp = GameObject.FindGameObjectWithTag("RoomLayout").GetComponent<RoomLayoutPrefabs>();
    }

    public void ChooseARoom()
    {
        if(roomType == RoomType.Side)
        {
            Instantiate(rlp.sides[Random.Range(0, rlp.sides.Length)], transform);
        }
        else if (roomType == RoomType.Corner)
        {
            Instantiate(rlp.corners[Random.Range(0, rlp.corners.Length)], transform);
        }
        else if (roomType == RoomType.Middle)
        {
            Instantiate(rlp.middles[Random.Range(0, rlp.middles.Length)], transform);
        }
    }

   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutRoomGenerator : MonoBehaviour
{
    public RoomLayoutPrefabs rlp;
    public bool side;
    public bool corner;
    public bool middle;

    private void Start()
    {
        rlp = GameObject.FindGameObjectWithTag("RoomLayout").GetComponent<RoomLayoutPrefabs>();
        ChooseARoom();
    }

    private void ChooseARoom()
    {
        if(side)
        {
            Instantiate(rlp.sides[Random.Range(0, rlp.sides.Length)], transform);
        }
        else if (corner)
        {
            Instantiate(rlp.corners[Random.Range(0, rlp.corners.Length)], transform);
        }
        else if (middle)
        {
            Instantiate(rlp.middles[Random.Range(0, rlp.middles.Length)], transform);
        }
    }
}

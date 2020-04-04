using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsleGenerator : MonoBehaviour
{
    public GameObject isleModel;
    public float xDistanceBetween;
    public float zDistanceBetween;
    public int xDepth;
    public int zDepth;
    public bool addRandomness = false;


    private Vector3 widthBetweenIsle;
    private Vector3 heightBetweenRows;

    private void Start()
    {
        SetValues();
        if(addRandomness)
        {
            RandomIsleSetup();
        }
        else
        {
            IsleSetup();
        }
    }

    private void IsleSetup()
    {
        Vector3 startPos;
        startPos = transform.position;
        float xStartPos = startPos.x;
        for (int i = 0; i < zDepth; i++)
        {
            for (int x = 0; x < xDepth; x++)
            {
                Instantiate(isleModel, startPos, transform.rotation, transform);
                startPos += widthBetweenIsle;
            }
            startPos += heightBetweenRows;
            startPos.x = xStartPos;
           
        }
    }
    private void RandomIsleSetup()
    {
        Vector3 startPos;
        startPos = transform.position;
        float xStartPos = startPos.x;
        for (int i = 0; i < zDepth; i++)
        {
            for (int x = 0; x < xDepth; x++)
            {
                Instantiate(isleModel, startPos, transform.rotation, transform);
                startPos += widthBetweenIsle;
            }
            startPos += heightBetweenRows;
            startPos.x = xStartPos;

        }
    }

    private void SetValues()
    {
        zDistanceBetween += isleModel.GetComponent<MeshRenderer>().bounds.size.z;
        xDistanceBetween += isleModel.GetComponent<MeshRenderer>().bounds.size.x;
        widthBetweenIsle.x = xDistanceBetween;
        heightBetweenRows.z = zDistanceBetween;
    }

 
}

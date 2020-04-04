using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AisleGenerator : MonoBehaviour
{
    public GameObject aisleModel;
    [Range(0f, 30f)]
    public float xDistanceBetween;
    [Range(0f, 50f)]
    public float zDistanceBetween;
    public int xDepth;
    public int zDepth;
    public bool addRandomness = false;


    private Vector3 widthBetweenIsle;
    private Vector3 heightBetweenRows;
    public bool showSpacing;

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
                Instantiate(aisleModel, startPos, transform.rotation, transform);
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
                Instantiate(aisleModel, startPos, transform.rotation, transform);
                startPos += widthBetweenIsle;
            }
            startPos += heightBetweenRows;
            startPos.x = xStartPos;

        
        }
        
    }

    private void SetValues()
    {
        zDistanceBetween += aisleModel.GetComponent<MeshRenderer>().bounds.size.z;
        xDistanceBetween += aisleModel.GetComponent<MeshRenderer>().bounds.size.x;
        widthBetweenIsle.x = xDistanceBetween;
        heightBetweenRows.z = zDistanceBetween;
    }

    private void OnDrawGizmos()
    {
        if(showSpacing)
        {
            Vector3 currentPosition = transform.position;
            float zPos = transform.position.z;
            for (int i = 0; i < zDepth; i++)
            {
                for (int x = 0; x < xDepth; x++)
                {
                    Gizmos.DrawCube(currentPosition, aisleModel.GetComponent<MeshRenderer>().bounds.size);
                    Gizmos.color = Color.red;
                    currentPosition += new Vector3(xDistanceBetween + aisleModel.GetComponent<MeshRenderer>().bounds.size.x, 0, 0);
                }
                currentPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                currentPosition += new Vector3(0, 0, i * (zDistanceBetween + aisleModel.GetComponent<MeshRenderer>().bounds.size.z));
            }

        }
        
    }
}
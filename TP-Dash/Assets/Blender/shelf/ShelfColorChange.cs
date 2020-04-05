using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfColorChange : MonoBehaviour
{
    public MeshRenderer[] boxes;
    public Color[] colorChoices;


    private void Start()
    {
        boxes = GetComponentsInChildren<MeshRenderer>();
        for (int i = 0; i < boxes.Length; i++)
        {
            if (i != 0)
            {
                boxes[i].material.color = colorChoices[Random.Range(0, colorChoices.Length)];
            }
        }
    }

}

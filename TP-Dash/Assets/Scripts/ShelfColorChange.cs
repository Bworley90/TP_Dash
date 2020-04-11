using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfColorChange : MonoBehaviour
{
    public Color[] colorChoices;
    private Material[] materialCount;


    private void Start()
    {
        BoxReduced();
    }

    private void BoxReduced()
    {
        materialCount = GetComponent<MeshRenderer>().materials;
        for (int i = 0; i < materialCount.Length; i++)
        {
            if(materialCount[i].name != "BaseColor (Instance)")
            {
                if(materialCount[i].name != "ShelfColor (Instance)")
                {
                    materialCount[i].color = colorChoices[Random.Range(0, colorChoices.Length)];
                }
            }
            
        }
    }

}

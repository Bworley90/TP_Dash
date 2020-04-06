using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesRackColorChange : MonoBehaviour
{
    public Color[] colorChoices;
    private Material[] materialCount;
    // Start is called before the first frame update
    void Start()
    {
        ColorSwap();
    }

    private void ColorSwap()
    {
        materialCount = GetComponent<MeshRenderer>().materials;
        for (int i = 0; i < materialCount.Length; i++)
        {
            if (materialCount[i].name != "Metal (Instance)")
            {
                materialCount[i].color = colorChoices[Random.Range(0, colorChoices.Length)];
            }

        }
    }
}

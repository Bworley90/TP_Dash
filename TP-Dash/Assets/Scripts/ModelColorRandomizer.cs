using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelColorRandomizer : MonoBehaviour
{
    public Color[] colors;
    public string skipMaterial1;
    public string skipMaterial2;
    private MeshRenderer mr;
    public Material[] materialCount;

    private void Start()
    {
        mr = GetComponent<MeshRenderer>();
        ChangeColors();
    }

    private void ChangeColors()
    {
        materialCount = mr.materials;
        for (int i = 0; i < materialCount.Length; i++)
        {
            if (materialCount[i].name != skipMaterial1 + " (Instance)")
            {
                if (materialCount[i].name != skipMaterial2 + " (Instance)")
                {
                    materialCount[i].color = colors[Random.Range(0, colors.Length)];
                }
                materialCount[i].color = colors[Random.Range(0, colors.Length)];
            }

        }
    }




}

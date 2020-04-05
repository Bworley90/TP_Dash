using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfColorChange : MonoBehaviour
{

    public Color[] colorChoices;

    private void Start()
    {
        GetComponent<MeshRenderer>().materials[1].color = colorChoices[Random.Range(0, colorChoices.Length)];
        GetComponent<MeshRenderer>().materials[2].color = colorChoices[Random.Range(0, colorChoices.Length)];
    }


}

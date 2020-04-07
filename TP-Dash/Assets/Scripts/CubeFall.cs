using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print(other.name);
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(gameObject, transform.position - Vector3.down, transform.rotation);
        }
    }
}

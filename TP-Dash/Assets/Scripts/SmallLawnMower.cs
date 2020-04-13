using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallLawnMower : MonoBehaviour
{
    private Animator anim;
    private bool inside;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            inside = true;
        }
        else
        {
            inside = false;
        }
    }

    private void Update()
    {
        if(inside)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                anim.SetTrigger("on");
            }
        }
    }
}

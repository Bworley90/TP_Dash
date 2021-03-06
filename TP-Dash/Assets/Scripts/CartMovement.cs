﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CartMovement : MonoBehaviour
{
    [Range(0f, 10f)]
    public float turnSpeed;
    private float speed;

    private void Update()
    {
        MoveCart();
    }

    private void MoveCart()
    {
        speed = StaticVariables.statics.cartSpeed;
        if(Input.GetAxisRaw("Vertical") > 0)
        {
            GetComponent<CharacterController>().SimpleMove(speed * transform.TransformDirection(Vector3.right));
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            GetComponent<CharacterController>().SimpleMove(speed * transform.TransformDirection(Vector3.left));
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Rotate(0, turnSpeed, 0);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Rotate(0, -1 * turnSpeed, 0);
        }
    }

    /*private void Movement()
    {
        speed = StaticVariables.statics.cartSpeed;
        if (GameManager.gm.state == GameManager.State.gameStarted)
        {
            if (Input.GetAxisRaw("Vertical") > 0)// Moving Forward
            {
                Vector3 newPosition = rb.position + transform.TransformDirection(Vector3.right * speed * Time.deltaTime);
                rb.MovePosition(newPosition);
            }
            else if (Input.GetAxisRaw("Vertical") < 0)
            {
                Vector3 newPosition = rb.position + transform.TransformDirection(Vector3.left * speed * Time.deltaTime);
                rb.MovePosition(newPosition);
            }
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                transform.Rotate(0, turnSpeed, 0);
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                transform.Rotate(0, -1 * turnSpeed, 0);
            }

            if (Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }*/
        
}

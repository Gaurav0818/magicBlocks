using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;


    private Rigidbody2D rb;
    private float moveInput;

    private bool isGrounded;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask WhatisGround;



    private bool rightDir = true; 

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, WhatisGround);

        moveInput = Input.GetAxis("Horizontal");

        if((rightDir && moveInput < 0) || (!rightDir && moveInput>0))
            rotate();

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    private void rotate()
    {
        rightDir = !rightDir;
        Vector3 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;
    }
}
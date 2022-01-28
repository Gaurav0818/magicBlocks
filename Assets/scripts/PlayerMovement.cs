using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;


    private Rigidbody2D rb;
    private float moveInput;

    private bool isGrounded;

    public Transform groundCheck_1;
    public Transform groundCheck_2;
    public float checkRadius;
    public LayerMask WhatisGround;

    public int extraJumpValue;
    private int extraJump;
    private float gravity;


    private bool rightDir = true; 

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gravity = rb.gravityScale;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        if (rb.velocity.y < 0)
            rb.gravityScale = gravity * 1.5f;
        else
            rb.gravityScale = gravity;
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck_1.position, checkRadius, WhatisGround);

        if (!isGrounded)
            isGrounded = Physics2D.OverlapCircle(groundCheck_2.position, checkRadius, WhatisGround);

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
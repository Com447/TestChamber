using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PlayerMove : MonoBehaviour

{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float wallJumpForce = 10f;
    public float wallSlideSpeed = 2f;
    public float wallJumpTime = 0.2f;
    public int maxWallJumps = 2;
    public LayerMask groundLayer;
    public LayerMask wallLayer;
    private Rigidbody2D rb;
    private bool isWallSliding = false;
    private int wallJumpCount = 0;
    private float timeSinceLastWallJump = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
        
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalMove * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded())
            {
                wallJumpCount = 0; // reset wall jump count when touching the ground
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            }
            else if (IsTouchingWall() && wallJumpCount < maxWallJumps && timeSinceLastWallJump > wallJumpTime)
            {
                wallJumpCount++;
                timeSinceLastWallJump = 0f;
                rb.velocity = new Vector2(0f, 0f); // reset horizontal velocity before applying wall jump force

                if (Input.GetAxisRaw("Horizontal") == 0) // jump straight up if no horizontal input
                {
                    rb.AddForce(new Vector2(0f, wallJumpForce), ForceMode2D.Impulse);
                }
                else // jump diagonally away from wall
                {
                    rb.AddForce(new Vector2(Mathf.Sign(horizontalMove) * wallJumpForce, jumpForce),
                        ForceMode2D.Impulse);
                }
            }
        }

        if (IsTouchingWall() && !IsGrounded() && rb.velocity.y < 0)
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, -wallSlideSpeed);
        }
        else
        {
            isWallSliding = false;
        }

        timeSinceLastWallJump += Time.deltaTime;
    }

    private bool IsGrounded()
    {
        float extraHeight = 0.1f;
        RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, Vector2.down,
            GetComponent<Collider2D>().bounds.extents.y + extraHeight, groundLayer);
        return raycastHit.collider != null;
    }

    private bool IsTouchingWall()
    {
        float extraWidth = 0.1f;
        float extraHeight = 0.2f;
        RaycastHit2D raycastHitLeft = Physics2D.Raycast(transform.position, Vector2.left,
            GetComponent<Collider2D>().bounds.extents.x + extraWidth, wallLayer);
        RaycastHit2D raycastHitRight = Physics2D.Raycast(transform.position, Vector2.right,
            GetComponent<Collider2D>().bounds.extents.x + extraWidth, wallLayer);
        RaycastHit2D raycastHitUp = Physics2D.Raycast(transform.position, Vector2.up,
            GetComponent<Collider2D>().bounds.extents.y + extraHeight, wallLayer);
        return raycastHitLeft.collider != null || raycastHitRight.collider != null || raycastHitUp.collider != null;
    }
}
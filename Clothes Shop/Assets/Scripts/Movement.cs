using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    private Vector2 currentMovement;
    private Vector2 currentDirection = new Vector2(0f, -1f);
    private bool isWalking = false;
    
    private void Update()
    {
        GetInput();
    }
    
    private void FixedUpdate()
    {
        Move();
    }

    private void GetInput()
    {
        currentMovement.x = Input.GetAxisRaw("Horizontal");
        currentMovement.y = Input.GetAxisRaw("Vertical");

        // Prevent diagonal movement
        if (currentMovement.x != 0)
        {
            currentMovement.y = 0f;
        }
        
        if(currentMovement.x != 0f || currentMovement.y != 0f)
        {
            if (!isWalking)
            {
                isWalking = true;
                animator.SetBool("isWalking", isWalking);
            }

            animator.SetFloat("Xmovement", currentMovement.x);
            animator.SetFloat("Ymovement", currentMovement.y);
            currentDirection = currentMovement;
        }
        else
        {
            if (isWalking)
            {
                isWalking = false;
                animator.SetBool("isWalking", isWalking);
            }
        }
    }

    private void Move()
    {
        rb.MovePosition(rb.position + currentMovement * movementSpeed * Time.fixedDeltaTime); 
    }

    public Vector2 GetCurrentDirection()
    {
        return currentDirection;
    }
}

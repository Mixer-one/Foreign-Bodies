using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    [SerializeField]private bool readyToJump = true;
    
    [Header("Ground Check")] 
    public float playerHeight;
    public LayerMask whatIsGround;
    [SerializeField]private bool grounded;

    private KeyCode jumpKey = KeyCode.Space;
    public Transform orientation;
    private float horizontalInput;
    private float verticalInput;
    private Vector3 moveDirection;
    private Rigidbody rb;
    
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void myInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (grounded && readyToJump && Input.GetKey(jumpKey))
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void movePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput; 
        if (grounded)
        {
            rb.AddForce(moveDirection * moveSpeed * 10f, ForceMode.Force);
        }
        else if (!grounded)
        {
            rb.AddForce(moveDirection * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }

    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
        myInput();
        SpeedControl();
    }

    private void FixedUpdate()
    {
        movePlayer();
    }
}

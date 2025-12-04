using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerControler : MonoBehaviour
{
   

    public GameObject BulletPrefab;  
    public float moveSpeed = 5f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new UnityEngine.Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

    }
    private void Shoot()
    {
        Instantiate(BulletPrefab, transform.position, Quaternion.identity);
    }

    
}
using System;
using UnityEditorInternal;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;


public class PlayerControler : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
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
        // Movimiento horizontal
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new UnityEngine.Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Verificar si está en el suelo
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        // Saltar
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new UnityEngine.Vector2(rb.linearVelocity.x, jumpForce);
        }

        if (Input.GetKey(KeyCode.X))
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        Instantiate(BulletPrefab, transform.position, Quaternion.identity);
    }
}
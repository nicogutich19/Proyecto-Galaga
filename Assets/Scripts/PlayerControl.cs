using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerInput = GetCoponent<PlayerInput>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 moveInput = playerInput.actions["Move"].ReadValue<Vector2>();
        playerRb.LinearVelocity = new Vector2(moveInput.x * SpeedTreeWindAsset, playerRb
    }
}

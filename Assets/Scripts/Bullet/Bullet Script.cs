using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.Numerics;


public class NewMonoBehaviourScript : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    private UnityEngine.Vector2 Direction;
    public float Speed;
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        Rigidbody2D.linearVelocity = UnityEngine.Vector2.up * Speed;
    }

    void Update()
    {
        
    }

}

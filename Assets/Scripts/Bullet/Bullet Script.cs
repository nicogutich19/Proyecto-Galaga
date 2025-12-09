using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;


public class NewMonoBehaviourScript : MonoBehaviour
{
    
    public float LifeTime = 3f;
    
    private Rigidbody2D Rigidbody2D;
    private UnityEngine.Vector2 Direction;
    public float Speed;
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Destroy(gameObject, LifeTime);
    }


    private void FixedUpdate()
    {
        Rigidbody2D.linearVelocity = UnityEngine.Vector2.up * Speed;
    }

    void Update()
    {
        
    }

        
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject); 
            Destroy(gameObject);

            GameManager.Instance.EnemyDestroyed();           
        }
    }

    


   

}

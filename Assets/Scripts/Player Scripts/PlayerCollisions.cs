using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private AudioClip deathSFX;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player ha muerto");
        AudioManager.Instance.PlaySFX(deathSFX);
        Destroy(gameObject, 0.2f);
        GameManager.instance.PlayerDied();
        
    }
}

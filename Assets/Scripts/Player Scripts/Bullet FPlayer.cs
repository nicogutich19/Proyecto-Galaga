using UnityEngine;

public class PlayerBulletFire : MonoBehaviour
{
    
    public GameObject bulletPrefab;
    public Transform firePoint;

    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (bulletPrefab != null && firePoint != null)
            {
                Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            }

            
        }

        
    }

    
}

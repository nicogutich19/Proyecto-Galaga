using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PSoundController : MonoBehaviour
{
    
    public AudioSource audioSource;
    public AudioClip ShootSound;
    public AudioClip ReceiveDamage;
    
    
    public void playShoot()
    {
        audioSource.PlayOneShot(ShootSound);
    }

    public void playReceiveDamage()
    {
        audioSource.PlayOneShot(ReceiveDamage);
    }

    
}

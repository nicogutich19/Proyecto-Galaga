using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource, sfxSource;
    public static AudioManager Instance { get; private set; }
    void Awake()
    {
        if(Instance != null)
        {
            Destroy(this.gameObject);
        } 
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
     public void PlayMusic(AudioClip musicClip)
    {
        musicSource.Stop();
        musicSource.clip = musicClip;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip sfxClip)
    {
        sfxSource.PlayOneShot(sfxClip);
    }
}

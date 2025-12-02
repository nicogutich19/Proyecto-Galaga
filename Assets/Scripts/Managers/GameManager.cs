using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] bool isPaused;
    public static GameManager Instance { get; private set; }
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

    public void ChangeScene(string nivel1)
    {
        SceneManager.LoadScene("nivel 1");
    }
    
    public void PauseGame()
    {
        isPaused = !isPaused;
        if(isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}

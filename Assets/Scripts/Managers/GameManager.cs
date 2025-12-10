using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance{get; private set;}
    private int EnemiesKilled = 0;
    [SerializeField] bool isPaused;
    void Awake() 
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    public void ChangeScene(string nameNewScene)
    {
        SceneManager.LoadScene(nameNewScene); 
    }
    private bool sceneChanged = false; // evita recargas repetidas
      

    public void EnemyKilled()
    {
        EnemiesKilled++;

        Debug.Log("Enemies Killed: " + EnemiesKilled);

        if (SceneManager.GetActiveScene().buildIndex == 1 && EnemiesKilled >= 3)
        {
            LoadNextLevel();
            EnemiesKilled = 0;
        } 

        if (SceneManager.GetActiveScene().buildIndex == 2 && EnemiesKilled >= 7)
        {
            ShowWinScreen();
            EnemiesKilled = 0;
        } 
    }

    public void PlayerDied()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(2);
        EnemiesKilled = 0;
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(2);
        EnemiesKilled = 0;
    }

    void ShowWinScreen()
    {
        Debug.Log("¡Has ganado!");
        SceneManager.LoadScene("End Game"); // crea una escena llamada "Win"
        EnemiesKilled = 0;
    }
}
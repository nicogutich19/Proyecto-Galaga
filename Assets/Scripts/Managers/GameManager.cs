using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance{get; private set;}
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
    void Update()
    {
        if (isPaused || sceneChanged) return;

        // Busca todos los objetos con el tag "enemy"
        if (GameObject.FindGameObjectsWithTag("enemy").Length == 0)
        {
            sceneChanged = true;
            // Cambia a la siguiente escena en el Build Settings
            int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if (nextIndex < SceneManager.sceneCountInBuildSettings)
                SceneManager.LoadScene(nextIndex);
            else
                Debug.Log("No hay más escenas en Build Settings para cargar.");
        }
    }   
}
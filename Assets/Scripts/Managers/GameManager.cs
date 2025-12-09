using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool isPaused;
    public static GameManager Instance { get; private set; }

    public GameObject pauseMenuUI;
    public GameObject pauseButton;

    private int enemiesDestroyed = 0;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log($"=== Escena cargada: {scene.name} ===");
    
        // Buscar las referencias UI en la nueva escena con manejo de errores
        try
        {
            pauseMenuUI = GameObject.FindGameObjectWithTag("PauseMenu");
            Debug.Log($"pauseMenuUI encontrado: {pauseMenuUI.name}");
        }
        catch (UnityException)
        {
            Debug.LogWarning($"No se encontró objeto con tag 'PauseMenu' en {scene.name}");
            pauseMenuUI = null;
        }
    
        try
        {
            pauseButton = GameObject.FindGameObjectWithTag("PauseButton");
            Debug.Log($"pauseButton encontrado: {pauseButton.name}");
        }
        catch (UnityException)
        {
            Debug.LogWarning($"No se encontró objeto con tag 'PauseButton' en {scene.name}");
            pauseButton = null;
        }

        if (pauseButton != null)
            pauseButton.SetActive(true);

        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(false);
    
            // Reiniciar el estado de pausa
            isPaused = false;
            Time.timeScale = 1f;
    }

    public void ChangeScene(string sceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }

    public void PauseGame()
    {
        if (!isPaused)
            ShowPauseMenu();
        else
            ResumeGame();
    }

    public void EnemyDestroyed()
    {
        enemiesDestroyed++;

        if (enemiesDestroyed >= 3)
        {
            ChangeScene("nivel 2");
        }
    }

    public void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }

    public void ResumeGame()
    {
        if (pauseMenuUI == null || pauseButton == null)
        {
            Debug.LogError("No se puede reanudar. Referencias nulas.");
            return;
        }

        isPaused = false;
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void ShowPauseMenu()
{
    // Si las referencias son nulas, intentar encontrarlas
    if (pauseMenuUI == null || pauseButton == null)
    {
        try
        {
            pauseMenuUI = GameObject.FindGameObjectWithTag("PauseMenu");
        }
        catch (UnityException)
        {
            Debug.LogError("No se encontró ningún objeto con el tag 'PauseMenu'. Asegúrate de que el tag existe y está asignado.");
            pauseMenuUI = null;
        }
        
        try
        {
            pauseButton = GameObject.FindGameObjectWithTag("PauseButton");
        }
        catch (UnityException)
        {
            Debug.LogError("No se encontró ningún objeto con el tag 'PauseButton'. Asegúrate de que el tag existe y está asignado.");
            pauseButton = null;
        }
        
        if (pauseMenuUI != null && pauseButton != null)
        {
            Debug.LogWarning("Referencias de UI reasignadas en ShowPauseMenu.");
        }
    }

    if (pauseMenuUI != null && pauseButton != null)
    {
        isPaused = true;
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
        pauseButton.SetActive(false);
    }
    else
    {
        Debug.LogError("No se pudo mostrar el menú de pausa. Referencias nulas.");
        Debug.LogError($"pauseMenuUI: {(pauseMenuUI == null ? "NULL" : "OK")}");
        Debug.LogError($"pauseButton: {(pauseButton == null ? "NULL" : "OK")}");
    }
}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }
}
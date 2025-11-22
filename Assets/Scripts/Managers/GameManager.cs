using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
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

    public void ChangeScene(string NewSceneName)
    {
        SceneManager.LoadScene(NewSceneName);
    }
    
}

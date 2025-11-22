using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    
    public void StartGame(string levelName)
    {
        GameManager.Instance.ChangeScene(levelName);
    }

    
}

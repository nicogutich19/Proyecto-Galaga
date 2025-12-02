using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    
    public void StartGame(string nivel1)
    {
        GameManager.Instance.ChangeScene("nivel1");
    }

    
}

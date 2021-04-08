using UnityEngine;

public class StartButton : MonoBehaviour
{

    public LevelManager levelManager;

    public void OnClick()
    {
        if (levelManager.inGame)
        {
            // Pause
        }
        else
            levelManager.StartGame();
    }

}

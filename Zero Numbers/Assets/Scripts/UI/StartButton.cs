using UnityEngine;

public class StartButton : MonoBehaviour
{

    public LevelManager levelManager;

    public void OnClick()
    {
        FindObjectOfType<AudioManager>().Play("Blip_SFX");
        if (levelManager.inGame)
        {
            // Pause
        }
        else
            levelManager.StartGame();
    }

}

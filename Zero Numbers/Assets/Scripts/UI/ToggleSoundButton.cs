using UnityEngine;

public class ToggleSoundButton : MonoBehaviour
{

    public SaveManager saveManager;

    public void OnClick()
    {
        if (saveManager.state.sfx)
            saveManager.state.sfx = false;
        else
            saveManager.state.sfx = true;

        saveManager.Save();
    }

}

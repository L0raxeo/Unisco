using UnityEngine;

public class SaveManager : MonoBehaviour
{

    public static SaveManager Instance { set; get; }
    public SaveState state;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
        Load();
    }

    // Save the whole state of this saveState script to the player pref
    public void Save()
    {
        PlayerPrefs.SetString("save", Utils.Serialize<SaveState>(state));
    }

    // Load the previous saved state from the player prefs
    public void Load()
    {
        // Do we already have a save?
        if (PlayerPrefs.HasKey("save"))
        {
            state = Utils.Deserialize<SaveState>(PlayerPrefs.GetString("save"));
        }
        else
        {
            state = new SaveState();
            Save();
            Debug.Log("No save file found, creating a new one...");
        }
    }

}

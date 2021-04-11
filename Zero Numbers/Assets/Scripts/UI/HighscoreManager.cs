using UnityEngine;
using TMPro;

public class HighscoreManager : MonoBehaviour
{

    public SaveManager saveManager;

    private TMP_Text highscore;

    private void Start()
    {
        highscore = GetComponent<TMP_Text>();

        highscore.text = saveManager.state.highscore.ToString();
    }

    public void checkHighscore(int score)
    {
        if (score > int.Parse(highscore.text))
        {
            highscore.text = score.ToString();
            saveManager.state.highscore = score;
            saveManager.Save();
        }
    }

}

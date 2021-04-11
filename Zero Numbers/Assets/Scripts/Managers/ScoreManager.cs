using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public TMP_Text scoreText;

    public void addScore(int score)
    {
        scoreText.text = (int.Parse(scoreText.text) + score).ToString();
    }

    public void setScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public int getScore()
    {
        return int.Parse(scoreText.text);
    }

}

using UnityEngine;

public class ContinueButton : MonoBehaviour
{

    private ShadeController shade;

    private void Start()
    {
        shade = GameObject.FindObjectOfType<ShadeController>();
    }

    public void OnClick()
    {
        FindObjectOfType<AudioManager>().Play("Blip_SFX");
        GameObject.Find("Game Over UI").SetActive(false);
        GameObject.FindObjectOfType<Board>().destroyAllPieces();
        GameObject.FindObjectOfType<HighscoreManager>().checkHighscore(GameObject.FindObjectOfType<ScoreManager>().getScore());
        GameObject.FindObjectOfType<ScoreManager>().setScore(0);
        shade.ToClear();
    }

}

using UnityEngine;
using UnityEngine.UI;

public class ReplaceButton : MonoBehaviour
{

    private Board board;

    private void Start()
    {
        GetComponent<Button>().interactable = false;
        board = GameObject.FindObjectOfType<Board>();
    }

    public void OnClick()
    {
        FindObjectOfType<AudioManager>().Play("Blip_SFX");
        if (GameObject.FindObjectOfType<LevelManager>().turns.getTurnsLeft() < 5)
            return;

        board.destroyAllPieces();
        board.fillAllSlots();
        GameObject.FindObjectOfType<MoveManager>().subtractTurns(5);

        if (GameObject.FindObjectOfType<MoveManager>().getTurnsLeft() == 0)
            GameObject.FindObjectOfType<LevelManager>().EndGame();
    }

}

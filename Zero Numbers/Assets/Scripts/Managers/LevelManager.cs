using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public GameObject m_camera;

    public Level level;
    public Board board;
    public MoveManager turns;

    public bool inGame = false;

    public void StartGame()
    {
        InitializeBoard();
        inGame = true;
    }

    public void EndGame()
    {

        inGame = false;
    }

    public void EndTurn()
    {

        level.selected = board.selected;

        if (board.selected[1] != null && board.selected[0] != null && board.selected[2] != null)
        {
            level.addition();
            level.pythagoreanTriple();
            level.repeated();
            level.consecutive();
            level.multiplication();
            level.power();
        }

        if (level.isMatchValid)
        {
            MatchValid(board.selected);
            turns.subtractTurns(1);
            if (turns.getTurnsLeft() == 0)
                EndGame();
        }
        else
        {
            m_camera.GetComponent<Animator>().SetBool("isShaking", true);
        }

        level.isMatchValid = false;

        foreach (GameObject o in GameObject.FindGameObjectsWithTag("Number"))
        {
            if (o.GetComponent<Number>().selected)
            {
                o.transform.localScale = new Vector3(1f, 1f, 1f);
                o.GetComponent<Number>().selected = false;
            }
        }

        for(int i = 0; i < board.selected.Length; i++)
        {
            board.selected[i] = null;
        }

        board.currentIndex = 0;
    }

    void MatchValid(GameObject[] selected)
    {
        foreach (GameObject o in selected)
        {
            if (o == null)
                return;

            var emptyCoordinates = o.transform.position;
            board.destroyPiece(o);
            board.fillSlot(emptyCoordinates);
        }
    }

    public void addSelectedPiece(GameObject number, string slot)
    {
        number.transform.localScale -= new Vector3(0.25f, 0.25f, 0f);
        board.addToSelected(number);
        number.GetComponent<Number>().selected = true;
    }

    void InitializeBoard()
    {
        board.fillAllSlots();
    }

}

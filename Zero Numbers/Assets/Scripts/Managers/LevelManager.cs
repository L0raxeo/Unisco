using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public GameObject m_camera;

    public Level level;
    public Board board;
    public MoveManager turns;
    public ParticleSystem crumbleFX;
    public ShadeController shade;
    public GameObject gameOverUI;
    public Button addMovesButton;

    [HideInInspector]
    public bool inGame = false;
    [HideInInspector]
    public bool watchedAd = false;

    public void StartGame()
    {
        InitializeBoard();
        turns.setTurns(50);
        addMovesButton.interactable = true;
        GameObject.Find("Replace Pieces").GetComponent<Button>().interactable = true;
        inGame = true;
        watchedAd = false;
    }

    public void EndGame()
    {
        inGame = false;

        addMovesButton.interactable = false;
        GameObject.Find("Replace Pieces").GetComponent<Button>().interactable = false;
        gameOverUI.SetActive(true);
        shade.ToSolid();

        if (watchedAd)
        {
            GameObject.Find("Watch Ad").GetComponent<Button>().interactable = false;
        }
        else
        {
            GameObject.Find("Watch Ad").GetComponent<Button>().interactable = true;
        }
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
            FindObjectOfType<AudioManager>().Play("Invalid_SFX");
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
        FindObjectOfType<AudioManager>().Play("Valid_SFX");

        if (board.getNumberOfSelected() >= 4)
        {
            Debug.Log("hi");
            turns.addTurns(4);
        }

        foreach (GameObject o in selected)
        {
            if (o == null)
                return;

            var emptyCoordinates = o.transform.position;
            board.destroyPiece(o);
            Instantiate(crumbleFX, new Vector3(o.transform.position.x, o.transform.position.y, -1f), Quaternion.Euler(0f, 0f, 45f));
            board.fillSlot(emptyCoordinates);
        }
    }

    public void addSelectedPiece(GameObject number, string slot)
    {
        number.transform.localScale -= new Vector3(0.25f, 0.25f, 0f);
        board.addToSelected(number);
        number.GetComponent<Number>().selected = true;
        FindObjectOfType<AudioManager>().Play("Pop_SFX");
    }

    void InitializeBoard()
    {
        board.fillAllSlots();
    }

}

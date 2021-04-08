using UnityEngine;

public class Finger : MonoBehaviour
{

    public LevelManager levelManager;

    private void Update()
    {
        getInput();
    }

    void getInput()
    {
        if (Input.touchCount > 0)
            OnTouch();
        else
            transform.position = new Vector2(1000f, 1000f);
    }

    void Move(Vector2 position)
    {
        transform.position = position;

        bool outOfBounds = transform.position.x > -1.75 && transform.position.x < 1.75 && transform.position.y < 1.7 && transform.position.y > -3.2;

        if (!outOfBounds) transform.position = new Vector2(1000f, 1000f);
    }

    void OnTouch()
    {
        Touch touch = Input.GetTouch(0);
        Move(Camera.main.ScreenToWorldPoint(touch.position));
    }

    void OnTouchRelease()
    {
        levelManager.EndTurn();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Untap" && levelManager.inGame)
        {
            OnTouchRelease();
            return;
        }

        if (!levelManager.inGame || collision.tag != "Number" || collision.GetComponent<Animator>().enabled || collision.transform.localScale.x <= 0.75f)
            return;

        if (levelManager.board.selected[1] != null)
        {
            if (levelManager.board.selected[0].transform.position.x == levelManager.board.selected[1].transform.position.x && collision.transform.position.x != levelManager.board.selected[1].transform.position.x)
            {
                Debug.Log(collision.transform.position.x);
                Debug.Log(levelManager.board.selected[1].transform.position.x);
                return;
            }
            else if (levelManager.board.selected[0].transform.position.y == levelManager.board.selected[1].transform.position.y && collision.transform.position.y != levelManager.board.selected[1].transform.position.y)
            {
                return;
            }
            else if (levelManager.board.isSlotSelected(collision.gameObject))
            {
                return;
            }
        }

        var piecePos = collision.transform.position;

        levelManager.addSelectedPiece(collision.gameObject, levelManager.board.getSlotID(collision.gameObject.transform.position));
    }

}

using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Board : MonoBehaviour
{

    public GameObject[] pieces;
    public GameObject[] selected;

    [HideInInspector]
    public int currentIndex = 0;

    public Dictionary<string, Vector2> board;

    private void Start()
    {
        board = new Dictionary<string, Vector2>();

        initializeBoardCoordinates();
    }

    public Vector2 getSlotCoordinate(int row, string column)
    {
        string slot = row + column;
        return board[slot];
    }

    public string getSlotID(Vector2 position)
    {
        foreach (var key in board.Keys.ToList())
        {
            if (board[key] == position)
                return key;
        }

        return null;
    }

    public void fillSlot(Vector3 position)
    {
        Instantiate(pieces[(int)Random.Range(0, 9)], position, Quaternion.identity);
    }

    public void fillAllSlots()
    {
        foreach (var key in board.Keys.ToList())
        {
            Instantiate(pieces[(int)Random.Range(0, 9)], board[key], Quaternion.identity);
        }
    }

    public void destroyPiece(int row, string column)
    {
        foreach(GameObject o in GameObject.FindGameObjectsWithTag("Number"))
        {
            if (o.transform.position.x == getSlotCoordinate(row, column).x && o.transform.position.y == getSlotCoordinate(row, column).y)
            {
                Destroy(o);
                Debug.Log("destroyed piece: " + o);
                break;
            }
        }
    }

    public void destroyPiece(GameObject o)
    {
        Destroy(o);
    }

    public void destroyAllPieces()
    {
        foreach(GameObject o in GameObject.FindGameObjectsWithTag("Number"))
        {
            Destroy(o);
        }
    }

    public void addToSelected(GameObject piece)
    {
            selected[currentIndex] = piece;
            currentIndex++;
    }

    public int getNumberOfSelected()
    {
        int number = 0;
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("Number"))
        {
            if (o.transform.localScale.x == 0.75)
            {
                number++;
            }
        }
        return number;
    }

    void initializeBoardCoordinates()
    {
        board.Add("1A", new Vector2(-1.4f, -2.85f));
        board.Add("1B", new Vector2(-0.7f, -2.85f));
        board.Add("1C", new Vector2(0.0f, -2.85f));
        board.Add("1D", new Vector2(0.7f, -2.85f));
        board.Add("1E", new Vector2(1.4f, -2.85f));
        board.Add("2A", new Vector2(-1.4f, -2.15f));
        board.Add("2B", new Vector2(-0.7f, -2.15f));
        board.Add("2C", new Vector2(0.0f, -2.15f));
        board.Add("2D", new Vector2(0.7f, -2.15f));
        board.Add("2E", new Vector2(1.4f, -2.15f));
        board.Add("3A", new Vector2(-1.4f, -1.45f));
        board.Add("3B", new Vector2(-0.7f, -1.45f));
        board.Add("3C", new Vector2(0.0f, -1.45f));
        board.Add("3D", new Vector2(0.7f, -1.45f));
        board.Add("3E", new Vector2(1.4f, -1.45f));
        board.Add("4A", new Vector2(-1.4f, -0.75f));
        board.Add("4B", new Vector2(-0.7f, -0.75f));
        board.Add("4C", new Vector2(0.0f, -0.75f));
        board.Add("4D", new Vector2(0.7f, -0.75f));
        board.Add("4E", new Vector2(1.4f, -0.75f));
        board.Add("5A", new Vector2(-1.4f, -0.05f));
        board.Add("5B", new Vector2(-0.7f, -0.05f));
        board.Add("5C", new Vector2(0.0f, -0.05f));
        board.Add("5D", new Vector2(0.7f, -0.05f));
        board.Add("5E", new Vector2(1.4f, -0.05f));
        board.Add("6A", new Vector2(-1.4f, 0.65f));
        board.Add("6B", new Vector2(-0.7f, 0.65f));
        board.Add("6C", new Vector2(0.0f, 0.65f));
        board.Add("6D", new Vector2(0.7f, 0.65f));
        board.Add("6E", new Vector2(1.4f, 0.65f));
        board.Add("7A", new Vector2(-1.4f, 1.35f));
        board.Add("7B", new Vector2(-0.7f, 1.35f));
        board.Add("7C", new Vector2(0.0f, 1.35f));
        board.Add("7D", new Vector2(0.7f, 1.35f));
        board.Add("7E", new Vector2(1.4f, 1.35f));
    }

}

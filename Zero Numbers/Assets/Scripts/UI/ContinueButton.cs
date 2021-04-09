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
        GameObject.Find("Game Over UI").SetActive(false);
        GameObject.FindObjectOfType<Board>().destroyAllPieces();
        shade.ToClear();
    }

}

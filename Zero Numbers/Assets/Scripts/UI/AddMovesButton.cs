using UnityEngine;
using UnityEngine.UI;

public class AddMovesButton : MonoBehaviour
{

    public GameObject movesUI;

    private void Start()
    {
        GetComponent<Button>().interactable = false;
    }

    public void OnClick()
    {
        FindObjectOfType<AudioManager>().Play("Blip_SFX");
        GameObject.FindObjectOfType<ShadeController>().ToSolid();
        movesUI.SetActive(true);
    }

}

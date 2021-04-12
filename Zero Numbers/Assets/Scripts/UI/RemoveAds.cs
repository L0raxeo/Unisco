using UnityEngine;
using UnityEngine.UI;

public class RemoveAds : MonoBehaviour
{

    public SaveManager saveManager;

    public GameObject removeAdsUI;

    private void Start()
    {
        if (!saveManager.state.ads)
        {
            GetComponent<Button>().interactable = false;
        }
    }

    public void OnClick()
    {
        FindObjectOfType<AudioManager>().Play("Blip_SFX");

        GameObject.FindObjectOfType<ShadeController>().ToSolid();
        removeAdsUI.SetActive(true);
    }

}

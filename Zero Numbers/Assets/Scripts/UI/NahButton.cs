using UnityEngine;

public class NahButton : MonoBehaviour
{

    public void OnClick()
    {
        FindObjectOfType<AudioManager>().Play("Blip_SFX");
        GameObject.Find("Remove Ads UI").SetActive(false);
        GameObject.FindObjectOfType<ShadeController>().ToClear();
    }

}

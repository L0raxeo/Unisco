using UnityEngine;

public class BackButton : MonoBehaviour
{

    public void OnClick()
    {
        FindObjectOfType<AudioManager>().Play("Blip_SFX");
        GameObject.FindObjectOfType<ShadeController>().ToClear();
        GameObject.Find("Store UI").SetActive(false);
    }

}

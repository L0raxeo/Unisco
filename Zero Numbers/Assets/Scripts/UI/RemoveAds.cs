using UnityEngine;

public class RemoveAds : MonoBehaviour
{

    public void OnClick()
    {
        FindObjectOfType<AudioManager>().Play("Blip_SFX");
    }

}

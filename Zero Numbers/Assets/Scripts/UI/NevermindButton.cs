using UnityEngine;

public class NevermindButton : MonoBehaviour
{

    public void OnClick()
    {
        FindObjectOfType<AudioManager>().Play("Blip_SFX");
        GameObject.Find("Shade").GetComponent<Animator>().SetBool("isSolid", false);
        GameObject.Find("Moves UI").SetActive(false);
    }

}

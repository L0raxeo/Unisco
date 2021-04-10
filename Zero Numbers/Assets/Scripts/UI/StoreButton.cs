using UnityEngine;

public class StoreButton : MonoBehaviour
{

    public GameObject storeUI;

    public void OnClick()
    {
        GameObject.Find("Shade").GetComponent<Animator>().SetBool("isSolid", true);
        storeUI.SetActive(true);
    }

}

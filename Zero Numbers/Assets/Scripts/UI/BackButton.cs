using UnityEngine;

public class BackButton : MonoBehaviour
{

    public void OnClick()
    {
        GameObject.FindObjectOfType<ShadeController>().ToClear();
        GameObject.Find("Store UI").SetActive(false);
    }

}

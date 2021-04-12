using UnityEngine;

public class PromoCodeButton : MonoBehaviour
{

    public GameObject textField;

    public void OnClick()
    {
        textField.SetActive(true);
    }

}

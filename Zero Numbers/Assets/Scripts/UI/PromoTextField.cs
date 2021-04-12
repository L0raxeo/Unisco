using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PromoTextField : MonoBehaviour
{

    private TMP_InputField textField;

    private void Start()
    {
        textField = gameObject.GetComponent<TMP_InputField>();
    }

    public void OnEdit()
    {
        if (textField.text == "Happy Birthday Mommy!")
        {
            GameObject.FindObjectOfType<SaveManager>().state.ads = false;
            GameObject.FindObjectOfType<SaveManager>().Save();
            GameObject.FindObjectOfType<BannerAdsManager>().RemoveBannerAds();
            GameObject.Find("Remove Ads").GetComponent<Button>().interactable = false;
        }

        GameObject.FindObjectOfType<ShadeController>().ToClear();
        GameObject.Find("Remove Ads UI").SetActive(false);
        textField.gameObject.SetActive(false);
    }

}

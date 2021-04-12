using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class YesButton : MonoBehaviour
{

    public GameObject storeUI;
    public TMP_Text coins;

    public void OnClick()
    {
        FindObjectOfType<AudioManager>().Play("Blip_SFX");
        int coins = int.Parse(this.coins.text.ToString());

        if (coins >= 50)
        {
            GameObject.FindObjectOfType<SaveManager>().state.coins -= 100;
            GameObject.FindObjectOfType<SaveManager>().Save();
            GameObject.FindObjectOfType<CoinsManager>().UpdateCoins();
            GameObject.FindObjectOfType<SaveManager>().state.ads = false;
            GameObject.FindObjectOfType<SaveManager>().Save();
            GameObject.Find("Remove Ads").GetComponent<Button>().interactable = false;
            GameObject.FindObjectOfType<BannerAdsManager>().RemoveBannerAds();
            GameObject.FindObjectOfType<ShadeController>().ToClear();
        }
        else
        {
            storeUI.SetActive(true);
        }

        GameObject.Find("Remove Ads UI").SetActive(false);
    }

}

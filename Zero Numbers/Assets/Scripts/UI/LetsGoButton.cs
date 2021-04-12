using UnityEngine;
using TMPro;

public class LetsGoButton : MonoBehaviour
{

    public GameObject storeUI;
    public TMP_Text coins;

    public void OnClick()
    {
        FindObjectOfType<AudioManager>().Play("Blip_SFX");
        int coins = int.Parse(this.coins.text.ToString());

        if (coins < 50)
        {
            GameObject.Find("Shade").GetComponent<Animator>().SetBool("isSolid", true);
            storeUI.SetActive(true);
        }
        else
        {
            GameObject.FindObjectOfType<SaveManager>().state.coins -= 50;
            GameObject.FindObjectOfType<SaveManager>().Save();
            GameObject.FindObjectOfType<CoinsManager>().UpdateCoins();
            GameObject.FindObjectOfType<ShadeController>().ToClear();
            GameObject.Find("Turns").GetComponent<TMP_Text>().text = (int.Parse(GameObject.Find("Turns").GetComponent<TMP_Text>().text) + 35).ToString();
        }
        GameObject.Find("Moves UI").SetActive(false);
    }

}

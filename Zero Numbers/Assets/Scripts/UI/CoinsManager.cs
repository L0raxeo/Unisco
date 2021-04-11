using UnityEngine;
using TMPro;

public class CoinsManager : MonoBehaviour
{

    public SaveManager saveManager;
    private TMP_Text coinsText;

    void Start()
    {
        UpdateCoins();
    }

    public void UpdateCoins()
    {
        coinsText = GetComponent<TMP_Text>();
        coinsText.text = saveManager.state.coins.ToString();
    }

}

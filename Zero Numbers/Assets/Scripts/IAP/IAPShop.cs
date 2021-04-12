using UnityEngine;
using UnityEngine.Purchasing;

public class IAPShop : MonoBehaviour
{

    public SaveManager saveManager;
    public CoinsManager coinManager;

    public GameObject restorPurchaseBtn;

    private string buy50Coins = "com.lowkey.lorcan.unisco.buy50coins";
    private string buy300Coins = "com.lowkey.lorcan.unisco.buy300coins";
    private string buy600Coins = "com.lowkey.lorcan.unisco.buy600coins";

    private void Awake()
    {
        DisableRestorePurchaseBtn();
    }

    public void OnPurchaseComplete(Product product)
    {
        if (product.definition.id == buy50Coins)
        {
            saveManager.state.coins += 50;
        }
        else if (product.definition.id == buy300Coins)
        {
            saveManager.state.coins += 300;
        }
        else if (product.definition.id == buy600Coins)
        {
            saveManager.state.coins += 600;
        }

        saveManager.Save();
        coinManager.UpdateCoins();
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
    {
        Debug.Log("Purchase of " + product.definition.id + " failed due to " + reason);
    }

    private void DisableRestorePurchaseBtn()
    {
        if (Application.platform != RuntimePlatform.IPhonePlayer)
        {
            restorPurchaseBtn.SetActive(false);
        }
    }

}

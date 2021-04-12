using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class BannerAdsManager : MonoBehaviour
{

    string gameID = "4085763";
    string bottomPlacementID = "banner";
    bool testMode = false;

    IEnumerator Start()
    {
        if (GameObject.FindObjectOfType<SaveManager>().state.ads)
        {
            Advertisement.Initialize(gameID, testMode);

            while (!Advertisement.IsReady(bottomPlacementID))
                yield return null;

            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Banner.Show(bottomPlacementID);
        }
    }

    public void RemoveBannerAds()
    {
        Advertisement.Banner.Hide();
    }

}

using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class OnStartAdsManager : MonoBehaviour
{

    IEnumerator Start()
    {
        if (GameObject.FindObjectOfType<SaveManager>().state.ads)
        {
            Advertisement.Initialize("4085763", false);

            while (!Advertisement.IsReady())
                yield return null;

            Advertisement.Show();
        }
    }

}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{

    private LevelManager levelManager;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();

        Advertisement.AddListener(this);
        Advertisement.Initialize("4085763", false);
    }

    public void ShowAd(string p)
    {
        Advertisement.Show(p);
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished && !levelManager.watchedAd)
        {
            FindObjectOfType<AudioManager>().Play("Blip_SFX");
            GameObject.FindObjectOfType<ShadeController>().ToClear();
            levelManager.inGame = true;
            levelManager.addMovesButton.interactable = true;
            GameObject.Find("Replace Pieces").GetComponent<Button>().interactable = true;
            levelManager.gameOverUI.SetActive(false);
            FindObjectOfType<MoveManager>().addTurns(15);
            levelManager.watchedAd = true;
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {

    }

    public void OnUnityAdsReady(string placementId)
    {

    }

    public void OnUnityAdsDidError(string message)
    {

    }

}

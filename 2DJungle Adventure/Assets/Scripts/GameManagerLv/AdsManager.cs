using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{

#if UNITY_IOS
        string gameId="4405358";
#else
    string gameId = "4405359";
#endif
    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(gameId);
        Advertisement.AddListener(this);
        
    }

    public void Playads()
    {
        if (Advertisement.IsReady("Interstitial_Android"))
        {
            Advertisement.Show("Interstitial_Android");
        }
    }

    public void PlayAdsReward()
    {
        if (Advertisement.IsReady("Rewarded_Android"))
        {
            Advertisement.Show("Rewarded_Android");
        }
    }
   
    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("Ads are Readdy");
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("Error" + message);
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Video Started");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId == "Rewarded Android" && showResult == ShowResult.Finished)
        {

        }
    }
}

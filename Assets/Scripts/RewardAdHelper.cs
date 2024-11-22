




using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Events;

public class RewardAdHelper : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{

    [SerializeField] private string _androidAdUnityID = "Rewarded_Android";
    [SerializeField] private string _iosAdUnityID = "Rewarded_iOS";

    private string _adUnityId;

    [SerializeField] private UnityEvent m_rewardAction;


    private void Awake()
    {
#if UNITY_ANDROID
        _adUnityId = _androidAdUnityID;
#else
    _adUnityId = _iosAdUnityID;
#endif
    }





    public void LoadAd()
    {
        Debug.Log("Loading Ad: " + _adUnityId);
        Advertisement.Load(_adUnityId, this);
    }

    public void ShowAd()
    {
        Debug.Log("Showing Ad: " + _adUnityId);
        Advertisement.Show(_adUnityId, this);
    }
    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Ad Loaded: " + placementId);

        if (_adUnityId.Equals(placementId))
        {
            ShowAd();
        }
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.LogError($"Error loading Ad Unit: {_adUnityId} - {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowClick(string placementId) { }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (_adUnityId.Equals(placementId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Unity Ads Rewraded Ad Completed");

            m_rewardAction.Invoke();
        }
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.LogError($"Error loading Ad Unit: {_adUnityId} - {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowStart(string placementId) { }

}
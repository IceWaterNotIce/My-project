using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAdHelper : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] private string _androidAdUnityID = "Interstitial_Android";
    [SerializeField] private string _iosAdUnityID = "Interstitial_IOS";

    private string _adUnityId;
    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit: {_adUnityId} - {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowClick(string placementId) { }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState) { }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.LogError($"Error loading Ad Unit: {_adUnityId} - {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowStart(string placementId) { }

    





    private void Awake()
    {
        _adUnityId = (Application.platform == RuntimePlatform.IPhonePlayer) ? _iosAdUnityID : _androidAdUnityID;
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






}
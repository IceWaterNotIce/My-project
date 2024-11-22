using UnityEngine;
using UnityEngine.Advertisements;

public class ADSInitializer : MonoBehaviour, UnityEngine.Advertisements.IUnityAdsInitializationListener
{
    [SerializeField] string _androidGameID;
    [SerializeField] string _iosGameID;
    [SerializeField] bool _testMode = true;

    [SerializeField] BannerAdHelper _bannerAdHelper;
    private string _gameID;
    public void InitializeAds()
    {
        _gameID = (Application.platform == RuntimePlatform.IPhonePlayer) ? _iosGameID : _androidGameID;

        Advertisement.Initialize(_gameID, _testMode, this);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");

        _bannerAdHelper.LoadBanner();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.LogErrorFormat("Unity Ads Initialization Failed: {0} - {1}", error.ToString(), message);
    }



    private void Awake()
    {
        InitializeAds();
    }



}

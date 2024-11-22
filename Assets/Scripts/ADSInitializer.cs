using UnityEngine;
using UnityEngine.Advertisements;

public class ADSInitializer : MonoBehaviour, UnityEngine.Advertisements.IUnityAdsInitializationListener
{
    [SerializeField] string _androidGameID;
    [SerializeField] string _iosGameID;
    [SerializeField] bool _testMode = true;
    private string _gameID;


public void OnInitializationComplete()
{
    Debug.Log("Unity Ads initialization complete.");
}

public void OnInitializationFailed(UnityAdsInitializationError error, string message)
{
   Debug.LogErrorFormat("Unity Ads Initialization Failed: {0} - {1}", error.ToString(), message);
}
Add a function “InitializeAds”

And call it on Awake Function	public void InitializeAds()
{
    _gameID = (Application.platform == RuntimePlatform.IPhonePlayer) ? _iosGameID : _androidGameID;

    Advertisement.Initialize(_gameID, _testMode, this);
}


private void Awake()
{
    InitializeAds();
}



}

using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAdHelper : MonoBehaviour
{
    [SerializeField] private string _androidAdUnitID = "Banner_Android";
    [SerializeField] private string _iosAdUnitID = "Banner_IOS";

    [SerializeField] private BannerPosition m_bannerPos = BannerPosition.BOTTOM_CENTER;

    private string _adUnitId;

    private void Start()
    {
        #if UNITY_ANDROID
            _adUnitId = _androidAdUnitID;
        #else
            _adUnitId = _iosAdUnitID;
        #endif
        Advertisement.Banner.SetPosition(m_bannerPos);
    }

    public void LoadBanner()
    {
        BannerLoadOptions loadOptions = new BannerLoadOptions
        {
            loadCallback = OnBannerLoaded,
            errorCallback = OnBannerError
        };

        Advertisement.Banner.Load(_adUnitId, loadOptions);
    }

    public void ShowbannerAd()
    {
        Advertisement.Banner.Show(_adUnitId);
    }

    public void OnBannerLoaded()
    {
        Debug.Log("Banner Loaded");

        ShowbannerAd();
    }

    public void HideBannerAd()
    {
        Advertisement.Banner.Hide();
    }

    public void OnBannerError(string msg)
    {
        Debug.LogError($"Baner Error: {msg}");
    }

}
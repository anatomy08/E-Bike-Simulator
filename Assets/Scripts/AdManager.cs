using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour , IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string androidGameId;
    [SerializeField] string iOSGameId;
    [SerializeField]  bool testMode = true;

    [SerializeField] string androidAdUnitId;
    [SerializeField] string iOSAdUnitId;

    public static AdManager instance;
    private string gameId;
    private string adUnitId;

    Playgame playgame;

    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else 
        {
            InitialiseAds();
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void InitialiseAds()
    {
#if UNITY_IOS
       gameId = iOSGameId;
       adUnitId = iOSAdUnitId;
#elif UNITY_ANDROID
       gameId =  androidGameId;
       adUnitId = androidAdUnitId;

#elif UNITY_EDITOR
        gameId =  androidGameId;
       adUnitId = androidAdUnitId;
#endif

if(!Advertisement.isInitialized)
{
Advertisement.Initialize(gameId, testMode, this);
}
       
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads initialization failed: {error.ToString()} - {message} ");
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Advertisement.Show(placementId,this);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        playgame.PlayGame();
    }

    public void ShowAd(Playgame playgame)
    {
        this.playgame = playgame;

        Advertisement.Load(adUnitId, this);
    }
}

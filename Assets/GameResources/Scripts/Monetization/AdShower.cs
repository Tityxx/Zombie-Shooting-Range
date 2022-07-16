using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdShower : MonoBehaviour
{
    public static AdShower Instance { get; private set; }

    private YandexSDK sdk => YandexSDK.instance;

    private static float lastInterstitialTime;

    private const float MINIMUM_INTERSTITIAL_DELAY = 6f;
    private const string REWARD_KEY = "Reward";

    private void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        lastInterstitialTime = Time.time;

        sdk.onRewardedAdReward += OnCloseReward;
        
        sdk.onUserDataReceived += OnSDKNull;
        sdk.onInterstitialShown += OnSDKNull;
        sdk.onInterstitialFailed += OnSDKNull;
        sdk.onRewardedAdOpened += OnSDKNull;
        sdk.onRewardedAdClosed += OnSDKNull;
        sdk.onRewardedAdError += OnSDKNull;
        sdk.onPurchaseSuccess += OnSDKNull;
        sdk.onPurchaseFailed += OnSDKNull;
        sdk.onClose += OnSDKNull;
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
            sdk.onRewardedAdReward -= OnCloseReward;
            
            sdk.onUserDataReceived -= OnSDKNull;
            sdk.onInterstitialShown -= OnSDKNull;
            sdk.onInterstitialFailed -= OnSDKNull;
            sdk.onRewardedAdOpened -= OnSDKNull;
            sdk.onRewardedAdClosed -= OnSDKNull;
            sdk.onRewardedAdError -= OnSDKNull;
            sdk.onPurchaseSuccess -= OnSDKNull;
            sdk.onPurchaseFailed -= OnSDKNull;
            sdk.onClose -= OnSDKNull;
        }
    }

    public static void ShowAd()
    {
        if (lastInterstitialTime + MINIMUM_INTERSTITIAL_DELAY > Time.time) return;

        lastInterstitialTime = Time.time;

        if (Application.isEditor)
        {
            Debug.Log("SHOW AD!");
        }
        else
        {
            YandexSDK.instance.ShowInterstitial();
        }
    }
    public static void ShowRewardAd()
    {
        if (Application.isEditor)
        {
            Debug.Log("SHOW REWARD!");
            Instance.OnCloseReward(REWARD_KEY);
        }
        else
        {
            YandexSDK.instance.ShowRewarded(REWARD_KEY);
        }
    }

    private void OnCloseReward(string key)
    {
        Currency.Value += 500;
    }

    private void OnOpenReward(int obj)
    {
    }

    private void OnCloseRewardFail(int obj)
    {
    }

    private void OnSDKNull(string obj)
    {
    }

    private void OnSDKNull(int i)
    {
    }

    private void OnSDKNull()
    {
    }
}
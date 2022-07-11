using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AdShower
{
    private static bool isSub;
    private const string REWARD_KEY = "Reward";

    public static void ShowAd()
    {
        if (Application.isEditor)
        {
            Debug.Log("SHOW AD!");
        }
        else
        {
            YandexSDK.instance?.ShowInterstitial();
        }
    }
    public static void ShowRewardAd()
    {
        if (Application.isEditor)
        {
            Debug.Log("SHOW REWARD!");
            OnCloseReward(REWARD_KEY);
        }
        else
        {
            if (!isSub)
            {
                YandexSDK.instance.onRewardedAdReward += OnCloseReward;
                isSub = true;
            }
            YandexSDK.instance?.ShowRewarded(REWARD_KEY);
        }
    }

    private static void OnCloseReward(string key)
    {
        if (key == REWARD_KEY)
            Currency.Value += 500;
    }
}
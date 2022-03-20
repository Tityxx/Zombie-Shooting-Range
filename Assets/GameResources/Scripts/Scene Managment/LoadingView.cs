using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Events;

/// <summary>
/// Переход между сцен
/// </summary>
public class LoadingView : MonoBehaviour
{
    public UnityEvent OnStartLoad;
    public UnityEvent OnEndLoad;

    [SerializeField]
    private float fadeDuration = 0.5f;
    [SerializeField]
    private float loadingDuration = 2f;

    [SerializeField]
    private CanvasGroup canvasGroup;
    [SerializeField]
    private Image imageFill;
    [SerializeField]
    private RandomEnabler randomEnabler;

    private static event Action onStartLoadScene = delegate { };
    private static bool isInited = false;

    private bool isLoaded = false;
    private bool isEndAnim = false;

    private void Awake()
    {
        if (isInited)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        canvasGroup.alpha = 0;
        imageFill.fillAmount = 0;

        onStartLoadScene += OnStartSceneLoad;
        SceneManager.sceneLoaded += OnSceneLoaded;
        isInited = true;
    }

    private void OnDestroy()
    {
        onStartLoadScene -= OnStartSceneLoad;
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnStartSceneLoad()
    {
        OnStartLoad.Invoke();
        randomEnabler.RandomEnable();
        canvasGroup.alpha = 1;
        imageFill.fillAmount = 0;
        imageFill.DOFillAmount(1, loadingDuration).SetUpdate(true).OnComplete(() =>
        {
            isEndAnim = true;
            TryDisableWindow();
        });
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        isLoaded = true;
        TryDisableWindow();
    }

    private void TryDisableWindow()
    {
        if (isLoaded && isEndAnim)
        {
            canvasGroup.DOFade(0, fadeDuration).SetUpdate(true).OnComplete(() =>
            {
                isLoaded = false;
                isEndAnim = false;
                OnEndLoad.Invoke();
            });
        }
    }

    /// <summary>
    /// Загрузка сцены
    /// </summary>
    public static void StartLoading()
    {
        onStartLoadScene();
    }
}

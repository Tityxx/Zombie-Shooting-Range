using System.Collections;
using System.Collections.Generic;
using ToolsAndMechanics.UserInterfaceManager;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Загрузка сцены по нажатию на кнопку
/// </summary>
public class LoadSceneButton : AbstractButton
{
    [SerializeField]
    private string sceneName;

    public override void OnButtonClick()
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Включение рандомного объекта
/// на OnEnable
/// </summary>
public class RandomEnabler : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objects;

    private void OnEnable()
    {
        RandomEnable();
    }

    /// <summary>
    /// Включение рандомного объекта
    /// </summary>
    public void RandomEnable()
    {
        int rand = Random.Range(0, objects.Count);
        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].SetActive(i == rand);
        }
    }
}

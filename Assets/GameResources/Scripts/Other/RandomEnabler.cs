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
        int rand = Random.Range(0, objects.Count - 1);
        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].SetActive(i == rand);
        }
    }
}

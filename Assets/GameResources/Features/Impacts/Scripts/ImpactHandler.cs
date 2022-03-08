using System.Collections;
using System.Collections.Generic;
using ToolsAndMechanics.ObjectPool;
using UnityEngine;

/// <summary>
/// Обработчик импакта
/// </summary>
public class ImpactHandler : MonoBehaviour
{
    [SerializeField]
    private PoolableObjectData data;
    [SerializeField]
    private float playingTime;

    private ObjectPoolController pool;

    private ParticleSystem particle;

    private void Awake()
    {
        pool = FindObjectOfType<ObjectPoolController>();
    }

    /// <summary>
    /// Взаимодействовать
    /// </summary>
    public void Impact(Vector3 position)
    {
        particle = pool.GetObject(data, position).GetComponent<ParticleSystem>();
        particle.Play();
        Invoke(nameof(ReturnToPool), playingTime);
    }

    private void ReturnToPool()
    {
        particle.Stop();
        pool.ReturnObject(particle.gameObject);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

/// <summary>
/// Абстрактный пул объектов
/// </summary>
public abstract class AbstractObjectPool<T> : MonoBehaviour where T: MonoBehaviour
{
    [SerializeField]
    private int InitCount = 10;
    [SerializeField]
    protected T prefab;

    protected ObjectPool<T> pool;

    protected virtual void Awake()
    {
        pool = new ObjectPool<T>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, true, InitCount, 10000);
    }

    /// <summary>
    /// Вызывается при создании объекта
    /// </summary>
    /// <returns></returns>
    protected abstract T CreatePooledItem();

    /// <summary>
    /// Вызывается при взятии объекта из пула
    /// </summary>
    /// <param name="obj"></param>
    protected abstract void OnTakeFromPool(T obj);

    /// <summary>
    /// Вызывается при возвращении объекта в пул
    /// </summary>
    /// <param name="obj"></param>
    protected abstract void OnReturnedToPool(T obj);

    /// <summary>
    /// Вызывается при переполнении ёмкости пула
    /// </summary>
    /// <param name="obj"></param>
    protected virtual void OnDestroyPoolObject(T obj)
    {
        Destroy(obj);
    }

    /// <summary>
    /// Взять из пула
    /// </summary>
    /// <returns></returns>
    public virtual T Get()
    {
        return pool.Get();
    }

    public virtual void Release(T obj)
    {
        pool.Release(obj);
    }
}

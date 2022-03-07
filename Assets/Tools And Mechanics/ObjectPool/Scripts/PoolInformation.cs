using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToolsAndMechanics.ObjectPool
{
    /// <summary>
    /// Скрипт для хранения объекта для пула и сам пул.
    /// Добавляется на каждый объект при инициализации пула.
    /// </summary>
    public class PoolInformation : MonoBehaviour
    {
        public ObjectPoolController ObjectPool;
        public PoolableObjectData Data;

        /// <summary>
        /// Возвращение объекта в пул
        /// </summary>
        public void ReturnToPool()
        {
            ObjectPool.ReturnObject(gameObject);
        }
    }
}
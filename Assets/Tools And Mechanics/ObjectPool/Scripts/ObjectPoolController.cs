using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ToolsAndMechanics.ObjectPool
{
    /// <summary>
    /// Контроллер пула объектов
    /// </summary>
    public class ObjectPoolController : MonoBehaviour
    {
        /// <summary>
        /// Инициализация пула
        /// </summary>
        public event Action OnPoolInit = delegate { };

        public bool IsInited => isInited;

        [SerializeField]
        private PoolableObjectData[] dataList;

        private Dictionary<PoolableObjectData, Queue<GameObject>> queue = new Dictionary<PoolableObjectData, Queue<GameObject>>();

        private bool isInited = false;

        private void Awake()
        {
            InitPool();
            isInited = true;
            OnPoolInit();
        }

        private void InitPool()
        {
            foreach (PoolableObjectData data in dataList)
            {
                queue.Add(data, new Queue<GameObject>());
                for (int i = 0; i < data.InitCount; i++)
                {
                    GameObject go = Instantiate(data.Prefab);
                    go.SetActive(false);

                    AddPoolInformation(go, data);

                    queue[data].Enqueue(go);
                }
            }
        }

        private void AddPoolInformation(GameObject go, PoolableObjectData data)
        {
            PoolInformation poolInfo = go.AddComponent<PoolInformation>();
            poolInfo.ObjectPool = this;
            poolInfo.Data = data;
        }

        /// <summary>
        /// Получить объект из пула
        /// </summary>
        /// <param name="data"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public GameObject GetObject(PoolableObjectData data, Vector3 position)
        {
            GameObject go;

            if (queue[data].Count > 0)
            {
                go = queue[data].Dequeue();
            }
            else
            {
                go = Instantiate(data.Prefab);
                AddPoolInformation(go, data);
            }
            go.transform.position = position;
            go.SetActive(true);
            return go;
        }

        /// <summary>
        /// Вернуть объект в пул
        /// </summary>
        /// <param name="go"></param>
        /// <returns> false, если такой тип объекта не был найден в пуле </returns>
        public bool ReturnObject(GameObject go)
        {
            if (go.TryGetComponent(out PoolInformation info))
            {
                go.SetActive(false);
                go.transform.parent = null;
                queue[info.Data].Enqueue(go);
                return true;
            }
            Debug.LogError($"Для объекта {go.name} не найден пул");
            return false;
        }
    }
}
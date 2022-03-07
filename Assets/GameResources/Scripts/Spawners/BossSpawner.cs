using System.Collections;
using System.Collections.Generic;
using ToolsAndMechanics.ObjectPool;
using UnityEngine;

/// <summary>
/// Спавн босса
/// </summary>
public class BossSpawner : MonoBehaviour
{
    [SerializeField]
    private PoolableObjectData data;
    [SerializeField]
    private AnimationCurve countCurve;
    [SerializeField]
    private AnimationCurve spawnDelayCurve;
    [SerializeField]
    private Transform[] spawnPoints;

    private ObjectPoolController pool;
    private float startTime;

    private void Start()
    {
        pool = FindObjectOfType<ObjectPoolController>();

        startTime = Time.time;
    }

    private IEnumerator SpawnCoroutine()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(1);


        }
    }

    private void Spawn(Vector3 position)
    {
        GameObject boss = pool.GetObject(data, position);
        boss.GetComponent<EnemyController>().SetPath();
    }
}

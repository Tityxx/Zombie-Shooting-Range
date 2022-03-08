using System.Collections;
using System.Collections.Generic;
using ToolsAndMechanics.ObjectPool;
using UnityEngine;

/// <summary>
/// Спавнер врагов
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private PoolableObjectData enemyData;

    [Space]
    [Header("Кол-во врагов для спавна по таймеру")]
    [SerializeField]
    private AnimationCurve countCurve;
    [Header("Задержка спавна по таймеру")]
    [SerializeField]
    private AnimationCurve spawnDelayCurve;
    [Header("Позиции для спавна по таймеру")]
    [SerializeField]
    private Transform[] positions;

    [Space]
    [Header("Сколько врагов спавнить одновременно на 1 точке старта")]
    [SerializeField]
    private int startCount = 1;
    [Header("Позиции для спавна на старте")]
    [SerializeField]
    private Transform[] positionsOnStart;

    private ObjectPoolController pool;
    private float startTime;

    private void Start()
    {
        pool = FindObjectOfType<ObjectPoolController>();
        startTime = Time.time;
        SpawnWave(startCount, positionsOnStart);
        StartCoroutine(SpawnWaveWithTimer());
    }

    private IEnumerator SpawnWaveWithTimer()
    {
        while (enabled)
        {
            SpawnWave((int)countCurve.Evaluate(Time.time - startTime), positions);
            
            yield return new WaitForSeconds(spawnDelayCurve.Evaluate(Time.time - startTime));
        }
    }

    private void SpawnWave(int count, Transform[] positions)
    {
        for (int j = 0; j < count; j++)
        {
            for (int i = 0; i < positions.Length; i++)
            {
                GameObject enemy = pool.GetObject(enemyData, positions[i].position);
                enemy.GetComponent<EnemyController>().SetPath();
            }
        }
    }
}

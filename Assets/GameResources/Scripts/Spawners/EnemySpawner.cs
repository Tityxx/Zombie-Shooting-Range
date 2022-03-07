using System.Collections;
using System.Collections.Generic;
using ToolsAndMechanics.ObjectPool;
using UnityEngine;

/// <summary>
/// Спавнер врагов
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    [Header("Задержка между спавном волн")]
    [SerializeField]
    private float delay = 1;
    [SerializeField]
    private PoolableObjectData enemyData;

    [Space]
    [Header("Сколько врагов спавнить одновременно на 1 точке таймера")]
    [SerializeField]
    private int timerCount = 1;
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

    private void Start()
    {
        pool = FindObjectOfType<ObjectPoolController>();
        SpawnWave(startCount, positionsOnStart);
        StartCoroutine(SpawnWaveWithTimer());
    }

    private IEnumerator SpawnWaveWithTimer()
    {
        while (enabled)
        {
            SpawnWave(timerCount, positions);
            
            yield return new WaitForSeconds(delay);
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

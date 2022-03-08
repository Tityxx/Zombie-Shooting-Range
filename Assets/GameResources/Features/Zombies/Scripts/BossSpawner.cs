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
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(spawnDelayCurve.Evaluate(Time.time - startTime));

            int count = (int)countCurve.Evaluate(Time.time - startTime);

            for (int i = 0; i < count; i++)
            {
                int rand = Random.Range(0, spawnPoints.Length);
                Spawn(spawnPoints[rand].position);
            }
        }
    }

    private void Spawn(Vector3 position)
    {
        GameObject boss = pool.GetObject(data, position);
        boss.GetComponent<EnemyController>().SetPath();
    }
}

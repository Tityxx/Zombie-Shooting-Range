using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Спавнер врагов
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float delay = 1;
    [SerializeField]
    private Transform[] positions;

    private EnemyObjectPool pool;

    private void Start()
    {
        pool = FindObjectOfType<EnemyObjectPool>();
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(delay);

            EnemyHealth enemy = pool.Get();
            int rand = Random.Range(0, positions.Length);
            enemy.transform.position = positions[rand].position;
            enemy.transform.rotation = positions[rand].rotation;
        }
    }
}

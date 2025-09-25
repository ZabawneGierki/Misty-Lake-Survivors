using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProgressiveSpawner : MonoBehaviour
{
    public List<EnemyWave> waves = new List<EnemyWave>();
    public float spawnRadius = 15f;

    Transform player;

    void Start()
    {
        StartCoroutine(FindPlayerThenSpawn());
    }

    IEnumerator FindPlayerThenSpawn()
    {
        while (player == null)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            if (p) player = p.transform;
            yield return null;
        }

        // Begin wave sequence
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        foreach (var wave in waves)
        {
            for (int i = 0; i < wave.amount; i++)
            {
                SpawnEnemy(wave.enemyPrefab);
                yield return new WaitForSeconds(wave.interval);
            }

            // Optional pause between waves
            yield return new WaitForSeconds(3f);
        }

        // After finishing all waves, you could:
        //   - loop back
        //   - spawn bosses
        //   - gradually repeat with higher stats
    }

    void SpawnEnemy(GameObject prefab)
    {
        if (!player) return;

        Vector2 dir = Random.insideUnitCircle.normalized;
        Vector2 spawnPos = (Vector2)player.position + dir * spawnRadius;
        Instantiate(prefab, spawnPos, Quaternion.identity);
    }
}

using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawning")]
    public GameObject enemyPrefab;
    public float spawnRadius = 15f;     // how far from the player to spawn
    public float spawnInterval = 2f;    // seconds between spawns
    public int maxEnemies = 50;

    Transform player;

    void Start()
    {
        // find the player after it spawns
        StartCoroutine(FindPlayerThenSpawn());
    }

    IEnumerator FindPlayerThenSpawn()
    {
        // Wait until the player exists
        while (player == null)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            if (p) player = p.transform;
            yield return null;
        }

        // Start spawning loop
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            if (CountActiveEnemies() < maxEnemies)
            {
                SpawnEnemy();
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy()
    {
        if (!player) return;

        // pick random direction around player
        Vector2 dir = Random.insideUnitCircle.normalized;
        Vector2 spawnPos = (Vector2)player.position + dir * spawnRadius;

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }

    int CountActiveEnemies()
    {
        return GameObject.FindGameObjectsWithTag("Enemy").Length;
    }
}

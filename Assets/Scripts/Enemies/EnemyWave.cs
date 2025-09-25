using UnityEngine;

[System.Serializable]
public class EnemyWave
{
    public GameObject enemyPrefab;
    public int amount = 5;
    public float interval = 2f;   // seconds between spawns
}

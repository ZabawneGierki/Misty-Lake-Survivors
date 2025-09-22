using UnityEngine;

public class Ofuda : WeaponBase
{
    public GameObject cardPrefab;

    protected override void Fire()
    {
        int count = level;                // 1 projectile per level
        float step = 360f / count;        // equal spacing
        float startAngle = Random.Range(0f, 360f); // random offset

        for (int i = 0; i < count; i++)
        {
            float angle = startAngle + step * i;
            Vector2 dir = DegreeToVector2(angle);
            SpawnCard(dir);
        }
    }

    void SpawnCard(Vector2 dir)
    {
        float spawnOffset = 0.5f; // distance from player center
        Vector3 spawnPos = transform.position + (Vector3)(dir.normalized * spawnOffset);

        var card = Instantiate(cardPrefab, spawnPos, Quaternion.identity)
                      .GetComponent<Projectile>();
        card.direction = dir.normalized;
        card.speed = GetProjectileSpeed();
        card.damage = GetDamage();
        card.transform.right = dir;
    }


    Vector2 DegreeToVector2(float angle)
    {
        float rad = angle * Mathf.Deg2Rad;
        return new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
    }
}

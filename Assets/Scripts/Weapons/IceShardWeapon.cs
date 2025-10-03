using UnityEngine;

public class IceShardWeapon : WeaponBase
{
    public GameObject iceShardPrefab;
    public float shardSpeed = 6f;

    protected override void Fire()
    {
        // Choose random direction (unit circle)
        Vector2 dir = Random.insideUnitCircle.normalized;

        // Compute the rotation that points the prefab’s right side along that direction
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);

        // ----- NEW: offset spawn position -----
        float spawnOffset = 0.5f; // distance from player center
        Vector3 spawnPos = transform.position + (Vector3)(dir * spawnOffset);

        // Instantiate shard at the offset position
        GameObject shardObj = Instantiate(iceShardPrefab, spawnPos, rot);

        // Apply size from WeaponBase
        float finalSize = GetSize();
        shardObj.transform.localScale *= finalSize;

        // Pass stats to the projectile
        var shard = shardObj.GetComponent<IceShard>();
        shard.Init(dir, shardSpeed, GetDamage(), level); // level = pierce count
    }
}

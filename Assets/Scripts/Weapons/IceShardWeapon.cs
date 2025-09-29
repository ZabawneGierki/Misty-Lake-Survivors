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

        // Instantiate shard
        GameObject shardObj = Instantiate(iceShardPrefab, transform.position, rot);

        // ----- Apply size from WeaponBase -----
        // baseSize * sizeMultiplier comes from WeaponBase
        float finalSize = GetSize();   // assuming WeaponBase has GetSize()
        shardObj.transform.localScale *= finalSize;

        // Pass stats to the projectile
        var shard = shardObj.GetComponent<IceShard>();
        shard.Init(dir, shardSpeed, GetDamage(), level); // level = pierce count
    }
}

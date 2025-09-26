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

        // Instantiate with the correct rotation
        var shard = Instantiate(iceShardPrefab, transform.position, rot)
                    .GetComponent<IceShard>();

        shard.Init(dir, shardSpeed, GetDamage(), level); // level = pierce count
    }
}

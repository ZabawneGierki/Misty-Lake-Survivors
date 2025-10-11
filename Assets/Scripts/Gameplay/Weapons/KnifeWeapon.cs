using UnityEngine;

public class KnifeWeapon : WeaponBase
{
    public GameObject knifePrefab;

    protected override void Fire()
    {
        Vector2 dir = GetPlayerAimDirection(); // e.g., last move dir
        GameObject knife = Instantiate(knifePrefab, transform.position, Quaternion.identity);
        knife.transform.localScale *= GetSize();
        knife.GetComponent<Rigidbody2D>().velocity = dir * GetProjectileSpeed();

        // you can pass damage to projectile if it has a script
        knife.GetComponent<Projectile>().damage = GetDamage();
    }

    Vector2 GetPlayerAimDirection()
    {
        // Access player's lastMoveDir or your own targeting logic
        return GetComponentInParent<PlayerMovement>().lastMoveDir;
    }
}

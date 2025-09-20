using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    [Header("Base Stats")]
    public int level = 1;
    public float baseCooldown = 1f;
    public float baseDamage = 10f;
    public float baseProjectileSpeed = 5f;
    public float baseSize = 1f;

    [Header("Modifiers (from power-ups)")]
    public float cooldownMultiplier = 1f;   // lower = faster
    public float damageMultiplier = 1f;
    public float speedMultiplier = 1f;
    public float sizeMultiplier = 1f;

    float nextFireTime;

    protected virtual void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + GetCooldown();
        }
    }

    public virtual void LevelUp()
    {
        level++;
        // Optionally scale base stats per level
    }

    public float GetCooldown() => baseCooldown * cooldownMultiplier;
    public float GetDamage() => baseDamage * damageMultiplier;
    public float GetProjectileSpeed() => baseProjectileSpeed * speedMultiplier;
    public float GetSize() => baseSize * sizeMultiplier;

    protected abstract void Fire();
}


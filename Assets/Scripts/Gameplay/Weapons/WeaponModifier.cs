using UnityEngine;

public class WeaponModifier : MonoBehaviour
{
    public void ApplyGlobalCooldownBoost(float factor)
    {
        foreach (var weapon in GetComponentsInChildren<WeaponBase>())
            weapon.cooldownMultiplier *= factor;
    }

    public void ApplyDamageBoost(float factor)
    {
        foreach (var weapon in GetComponentsInChildren<WeaponBase>())
            weapon.damageMultiplier *= factor;
    }
}

using UnityEngine;

[CreateAssetMenu(menuName = "BulletHeaven/PowerUps/Weapon Size Boost")]
public class WeaponSizeBoost : PowerUpEffect
{
    [Tooltip("Extra size per level, e.g. 0.1 = +10%")]
    public float sizeBonusPerLevel = 20f;

    public override void Apply(PlayerInventory inventory, int newLevel)
    {
        // multiplier = 1 + (bonus * level)
        float multiplier = 1f + sizeBonusPerLevel * newLevel;

        foreach (var w in inventory.weapons)
        {
            // WeaponBase already has sizeMultiplier from earlier design
            if (w.instance)
            {
                var baseScript = w.instance.GetComponent<WeaponBase>();
                if (baseScript != null)
                    baseScript.speedMultiplier = multiplier;
                else 
                    Debug.LogWarning($"Weapon {w.data.weaponName} does not have a WeaponBase component.");
            }
        }
    }
}

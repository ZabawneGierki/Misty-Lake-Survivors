using UnityEngine;

public class AuraWeapon : WeaponBase
{
    public GameObject auraPrefab;
    private GameObject auraInstance;
    private AuraField auraField;

    protected override void Fire()
    {
        // Aura is persistent: spawn it once and keep updating stats
        if (auraInstance == null)
        {
            auraInstance = Instantiate(auraPrefab, transform.position, Quaternion.identity, transform);
            auraField = auraInstance.GetComponent<AuraField>();
        }

        // Update its stats every time Fire is called
        auraField.UpdateStats(GetDamage(), GetSize(), attackCooldown);
    }
}

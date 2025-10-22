using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaichanAura : WeaponBase
{
    public GameObject auraPrefab;
    private GameObject auraInstance;
    private AuraField auraField;
    private float sizeIncrement = 0.5f;

    protected override void Fire()
    {
        if (auraInstance == null)
        {
            // Spawn once, parent to player
            auraInstance = Instantiate(auraPrefab, transform.position, Quaternion.identity, transform);
            auraField = auraInstance.GetComponent<AuraField>();
        }

        // Calculate size based on base size + (level-1 * increment)
        float levelBasedSize = GetSize() + ((level - 1) * sizeIncrement);
        
        // Update aura stats each fire call
        auraField.UpdateStats(GetDamage(), levelBasedSize);
        auraField.DealDamage();
    }
}

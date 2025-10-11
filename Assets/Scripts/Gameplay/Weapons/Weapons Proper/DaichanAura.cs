using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaichanAura : WeaponBase
{
    public GameObject auraPrefab;
    private GameObject auraInstance;
    private AuraField auraField;

    protected override void Fire()
    {
        Debug.Log($"Firing Daichan Aura at {Time.timeSinceLevelLoad:F2} seconds");
        if (auraInstance == null)
        {
            // Spawn once, parent to player
            auraInstance = Instantiate(auraPrefab, transform.position, Quaternion.identity, transform);
            auraField = auraInstance.GetComponent<AuraField>();
             
        }

        // Update aura stats each fire call (damage, size, tick speed)
        // random size for now
        

        auraField.UpdateStats(GetDamage(), GetSize());
        auraField.DealDamage();
    }
}

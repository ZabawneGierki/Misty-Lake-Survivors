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
        if (auraInstance == null)
        {
            // Spawn once, parent to player
            auraInstance = Instantiate(auraPrefab, transform.position, Quaternion.identity, transform);
            auraField = auraInstance.GetComponent<AuraField>();
             
        }

        // Update aura stats each fire call (damage, size, tick speed)
        // random size for now
        float randomSize = Random.Range(0.5f, 2.2f);

        auraField.UpdateStats(GetDamage(), randomSize);
        auraField.DealDamage();
    }
}

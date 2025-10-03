using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : WeaponBase
{
    public float damagePerTick = 5f;
    public float tickRate = 0.2f; // damage every 0.2s
    public float lifetime = 1f;   // how long beam exists

    public LayerMask enemyLayer;

    void Start()
    {
        StartCoroutine(LifetimeRoutine());
        StartCoroutine(DamageRoutine());
    }

    IEnumerator LifetimeRoutine()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }

    IEnumerator DamageRoutine()
    {
        while (true)
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position,
                                                       transform.right, // laser direction
                                                       20f,  enemyLayer           // max length
                                                        );

            foreach (var hit in hits)
            {
                EnemyHealth enemy = hit.collider.GetComponent<EnemyHealth>();
                if (enemy != null)
                    enemy.TakeDamage(damagePerTick);
            }

            yield return new WaitForSeconds(tickRate);
        }
    }

    protected override void Fire()
    {
        throw new System.NotImplementedException();
    }
}

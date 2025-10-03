using UnityEngine;
using System.Collections.Generic;

public class AuraField : MonoBehaviour
{
    public CircleCollider2D areaCollider; // set as trigger
    public SpriteRenderer sprite;         // optional visual

    public float tickRate = 0.1f;
    public float timer = 0f;
    public float damage = 65f;

    private readonly List<EnemyHealth> enemiesInRange = new List<EnemyHealth>();

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= tickRate)
        {
            timer = 0f;
            ApplyDamage();
        }
    }

    public void Init(float dmg, float size, float cooldown)
    {
        damage = dmg;
        tickRate = cooldown; // reuse cooldown as tick interval
        UpdateSize(size);
    }

    public void UpdateStats(float dmg, float size, float cooldown)
    {
        damage = dmg;
        tickRate = cooldown;

        // Assume prefab collider radius = 1 = base size
        areaCollider.radius = size;

        // Scale sprite so it matches collider diameter
        if (sprite != null)
        {
            float diameter = areaCollider.radius * 2f;
            sprite.transform.localScale = new Vector3(diameter, diameter, 1f);
        }
    }

    private void UpdateSize(float size)
    {
        // Scale collider + visual sprite
        areaCollider.radius = 1f * size; // base radius times size multiplier
        //if (sprite != null) sprite.transform.localScale = Vector3.one * size * 2f;
    }

    private void ApplyDamage()
    {
        for (int i = enemiesInRange.Count - 1; i >= 0; i--)
        {
            var enemy = enemiesInRange[i];
            if (enemy == null)
            {
                enemiesInRange.RemoveAt(i); // clean up destroyed enemies
                continue;
            }

            enemy.TakeDamage(damage);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            var enemy = col.GetComponent<EnemyHealth>();
            if (enemy != null && !enemiesInRange.Contains(enemy))
                enemiesInRange.Add(enemy);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            var enemy = col.GetComponent<EnemyHealth>();
            if (enemy != null && enemiesInRange.Contains(enemy))
                enemiesInRange.Remove(enemy);
        }
    }
}

using UnityEngine;
using System.Collections.Generic;

public class AuraField : MonoBehaviour
{
    public CircleCollider2D areaCollider; // set as trigger
    public SpriteRenderer sprite;         // optional visual

    private float tickRate = 1f;
    private float timer = 0f;
    private float damage = 1f;

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
        UpdateSize(size);
    }

    private void UpdateSize(float size)
    {
        // Scale collider + visual sprite
        areaCollider.radius = 1f * size; // base radius times size multiplier
        if (sprite != null) sprite.transform.localScale = Vector3.one * size * 2f;
    }

    private void ApplyDamage()
    {
        foreach (var enemy in enemiesInRange)
        {
            if (enemy != null) enemy.TakeDamage(damage);
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

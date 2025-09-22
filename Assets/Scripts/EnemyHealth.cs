using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHP = 20f;
    float currentHP;

    void Awake() => currentHP = maxHP;

    public void TakeDamage(float dmg)
    {
        currentHP -= dmg;
        if (currentHP <= 0f) Die();
    }

    void Die()
    {
        // Play death FX, drop loot, etc.
        Destroy(gameObject);
    }
}
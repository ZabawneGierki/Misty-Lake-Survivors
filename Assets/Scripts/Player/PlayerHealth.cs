using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    public float maxHealth = 100f;
    public float currentHealth;

    [Header("UI")]
    public PlayerHealthBar healthBar;   // assign the bar prefab/instance in Inspector

    // Event fired when health reaches 0
    public static UnityEvent OnPlayerDied = new UnityEvent();

    void Awake()
    {
        currentHealth = maxHealth;
        if (healthBar) healthBar.SetHealth(currentHealth, maxHealth);
    }


     

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10f); // Example damage value
        }
    }
    public void TakeDamage(float dmg)
    {
        currentHealth = Mathf.Max(currentHealth - dmg, 0);
        if (healthBar) healthBar.SetHealth(currentHealth, maxHealth);

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        // Fire the global event so other objects (UI, music, etc.) can react
        OnPlayerDied.Invoke();
        // Optional: disable movement, play animation, etc.
        gameObject.SetActive(false);
    }
}


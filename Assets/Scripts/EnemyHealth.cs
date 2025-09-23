using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyHealth : MonoBehaviour
{
    [Header("Health")]
    public float maxHealth = 10f;
    private float currentHealth;

    [Header("Hit Flash")]
    public Color flashColor = Color.white;
    public float flashDuration = 0.1f;

    [Header("Death")]
    public GameObject deathEffectPrefab;

    SpriteRenderer sr;
    Color originalColor;

    void Awake()
    {
        currentHealth = maxHealth;
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }

    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;
        if (currentHealth <= 0f)
        {
            Die();
            return;
        }
        StartCoroutine(Flash());
    }

    System.Collections.IEnumerator Flash()
    {

        sr.color = flashColor;
        // turn invisible for a short duration
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0f);

        yield return new WaitForSeconds(flashDuration);
        sr.color = originalColor;
    }

    void Die()
    {
        if (deathEffectPrefab)
        {
            Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
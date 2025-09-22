using UnityEngine;
using System.Collections;
using DG.Tweening;

public enum ProjectileType { Bullet, Laser }

[RequireComponent(typeof(Collider2D))]
public class Projectile : MonoBehaviour
{
    public ProjectileType type = ProjectileType.Bullet;

    // Shared
    public float damage = 10f;
    public float lifetime = 5f;

    // Bullet settings
    public Vector2 direction;
    public float speed;

    // Laser settings
    public float tickRate = 0.2f;     // damage interval
    public float maxLength = 20f;
    public LayerMask enemyMask;


    private void Awake()
    {
         
        // make invisible initially if it's a bullet
        if (type != ProjectileType.Bullet) return;

        var sr = GetComponent<SpriteRenderer>();
        

            if (sr != null)
        {
            Color c = sr.color;
            c.a = 0f;
            sr.color = c;
        }
        // fade in
        if (sr != null)
        {
            sr.DOFade(1f, .2f);
        }
    }
    void Start()
    {
        if (type == ProjectileType.Bullet)
        {
            Destroy(gameObject, lifetime);
        }
        else if (type == ProjectileType.Laser)
        {
            StartCoroutine(LaserRoutine());
            StartCoroutine(Lifetime());
        }
    }

    void Update()
    {
        if (type == ProjectileType.Bullet)
        {
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (type != ProjectileType.Bullet) return; // laser handles hits itself
        EnemyHealth enemy = other.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    IEnumerator Lifetime()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }

    IEnumerator LaserRoutine()
    {
        while (true)
        {
            // Cast a straight ray from origin in local right direction
            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position,
                                                       transform.right,
                                                       maxLength,
                                                       enemyMask);
            foreach (var hit in hits)
            {
                EnemyHealth enemy = hit.collider.GetComponent<EnemyHealth>();
                if (enemy != null)
                    enemy.TakeDamage(damage);
            }

            yield return new WaitForSeconds(tickRate);
        }
    }
}

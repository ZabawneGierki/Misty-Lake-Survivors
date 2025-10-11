using DG.Tweening.Core.Easing;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class IceShard : MonoBehaviour
{
    public float speed;
    public float damage;
    public int pierceCount;
    public int maxBounces = 6;



    Rigidbody2D rb;
    int bounces = 0;
    Animator animator;

    [HideInInspector] public Vector2 direction; // set from spawner/weapon


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void Init(Vector2 direction, float spd, float dmg, int pierces)
    {
        this.direction = direction;
        speed = spd;
        damage = dmg;
        pierceCount = pierces;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction.normalized * speed;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            col.GetComponent<EnemyHealth>()?.TakeDamage(damage);
            pierceCount--;

            if (pierceCount <= 0)
                StartCoroutine(PlayDestroyAnimation());
        }
        else if (col.CompareTag("ScreenEdge"))
        {
            // Compute robust normal using the closest point on the collider
            Vector2 closest = col.ClosestPoint(transform.position);
            Vector2 normal = ((Vector2)transform.position - closest);

            if (normal.sqrMagnitude < 1e-6f)
            {
                // fallback — avoid zero normal (e.g. when overlapping slightly)
                normal = -direction;
            }
            normal.Normalize();

            // incoming direction depends on how you move the shard
            Vector2 incoming = (rb != null && rb.bodyType != RigidbodyType2D.Kinematic)
                               ? rb.velocity.normalized
                               : direction.normalized;

            Vector2 reflected = Vector2.Reflect(incoming, normal).normalized;

            // limit bounces
            bounces++;
            if (bounces > maxBounces)
            {
                Destroy(gameObject);
                return;
            }

            // apply new direction/velocity
            if (rb != null && rb.bodyType != RigidbodyType2D.Kinematic)
                rb.velocity = reflected * speed;
            else
                direction = reflected;

            // rotate sprite to face travel direction (optional)
            transform.right = reflected;
        }
    }


    private IEnumerator PlayDestroyAnimation()
    {
        animator.SetTrigger("Explode");
        yield return new WaitForSeconds(0.3f); // wait for animation to finish
        Destroy(gameObject);
    }
}

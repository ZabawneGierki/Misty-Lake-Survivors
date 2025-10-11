using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyChase : MonoBehaviour
{
    public float moveSpeed = 3f;
    Transform player;
    Rigidbody2D rb;
    SpriteRenderer sr;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>(); // or GetComponent<SpriteRenderer>()
    }

    void FixedUpdate()
    {
        if (!player) return;

        Vector2 dir = ((Vector2)player.position - rb.position).normalized;
        rb.MovePosition(rb.position + dir * moveSpeed * Time.fixedDeltaTime);

        // Flip horizontally if needed
        if (sr)
        {
            // Facing left by default, so flip when player is to the RIGHT
            sr.flipX = (player.position.x > transform.position.x);
        }
    }
}

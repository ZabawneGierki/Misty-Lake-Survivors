using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    Rigidbody2D rb;
    Vector2 input;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Read WASD/Arrow keys or controller stick
        input = new Vector2(Input.GetAxisRaw("Horizontal"),
                            Input.GetAxisRaw("Vertical")).normalized;
    }

    void FixedUpdate()
    {
        rb.velocity = input * moveSpeed;
    }
}

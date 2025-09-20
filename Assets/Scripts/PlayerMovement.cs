using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";
    private const string MoveX = "MoveX";
    private const string MoveY = "MoveY";
    private const string SpeedValue = "Speed";
    public float moveSpeed = 5f;
    public Animator animator;
    
    Rigidbody2D rb;
    Vector2 input;
     
    public Vector2 lastMoveDir = Vector2.down;   // start facing down if you like

    void Awake() => rb = GetComponent<Rigidbody2D>();


    void Update()
    {
        Vector2 raw = new Vector2(Input.GetAxisRaw(HorizontalAxis),
                                  Input.GetAxisRaw(VerticalAxis));

        input = raw.normalized;

        // If we are moving, update lastMoveDir
        if (raw.sqrMagnitude > 0.01f)
        {
            lastMoveDir = input;
        }

        // When idle, use lastMoveDir instead of zeros
        Vector2 animDir = (raw.sqrMagnitude > 0.01f) ? input : lastMoveDir;

        animator.SetFloat(MoveX, animDir.x);
        animator.SetFloat(MoveY, animDir.y);
        animator.SetFloat(SpeedValue, raw.sqrMagnitude); // still based on raw input
    }

    void FixedUpdate()
    {
        rb.velocity = input * moveSpeed;
    }
}

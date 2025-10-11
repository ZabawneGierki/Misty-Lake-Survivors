using UnityEngine;

public class ItemMagnet : MonoBehaviour
{
    [Header("Magnet Settings")]
    public float baseRadius = 2f;   // starting pickup radius
    public float radiusMultiplier = 1f; // upgrade multiplier
    public float pullSpeed = 5f;    // how fast items fly to player

    private CircleCollider2D magnetCollider;

    void Awake()
    {
        // Add an invisible trigger collider
        magnetCollider = gameObject.AddComponent<CircleCollider2D>();
        magnetCollider.isTrigger = true;
        magnetCollider.radius = baseRadius;
    }

    void Update()
    {
        // keep collider updated if radius changes
        magnetCollider.radius = baseRadius * radiusMultiplier;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Pickup"))
        {
            // smoothly move item towards player
            col.transform.position = Vector3.MoveTowards(
                col.transform.position,
                transform.position,
                pullSpeed * Time.deltaTime
            );
        }
    }

    // Call this when a magnet power-up is picked
    public void UpgradeMagnet(float extraMultiplier)
    {
        radiusMultiplier += extraMultiplier;
    }
}

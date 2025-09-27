using UnityEngine;

public class GemPickUp : MonoBehaviour
{
    public int xpValue = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerLevel>()?.AddXP(xpValue);
            Destroy(gameObject);
        }
    }
}


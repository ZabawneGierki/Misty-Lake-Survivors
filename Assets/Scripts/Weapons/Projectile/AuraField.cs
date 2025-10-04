using UnityEngine;
using System.Collections.Generic;

public class AuraField : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; // assign in prefab

    private float tickRate = 1f;
    private float timer = 0f;
    private float damage = 1f;
    private float radius = 1f;


    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= tickRate)
        {
           DealDamage();
            timer = 0f;
        }
    }

    public void UpdateStats(float dmg, float size, float cooldown)
    { 
         
    }

    void OnDrawGizmos()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        if (spriteRenderer != null && spriteRenderer.sprite != null)
        {
            // Get the sprite bounds
            Bounds spriteBounds = spriteRenderer.sprite.bounds;

            // Calculate the radius based on the sprite's extents (half the width or height)
            // We take the maximum of the two to ensure it encompasses the entire sprite
            float radius = Mathf.Max(spriteBounds.extents.x, spriteBounds.extents.y);

            // Store the current Gizmos matrix and color
            Matrix4x4 oldMatrix = Gizmos.matrix;
            Color oldColor = Gizmos.color;

            // Set the gizmo color (e.g., yellow) and a custom matrix to draw a 2D circle
            Gizmos.color = Color.yellow;
            // For a 2D circle, we set the z scale to 1 and preserve the sprite's aspect ratio
            Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, new Vector3(1, 1, 1));

            // Draw the circle at the center of the sprite's bounds
            Gizmos.DrawWireSphere(spriteBounds.center, radius);

            // Restore the old Gizmos matrix and color
            Gizmos.matrix = oldMatrix;
            Gizmos.color = oldColor;
        }
    }


    public void DealDamage( )
    {
        Debug.Log($"Dealing damage to enemies within radius. Time passed: {Time.timeSinceLevelLoad:F2}" );
    }



}

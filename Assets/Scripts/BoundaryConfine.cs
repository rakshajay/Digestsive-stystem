using UnityEngine;

public class BoundaryConfine : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Out_Collider"))
        {
            // This example simply stops the germ's movement
            // You might want to add more logic to redirect it back
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.zero; // Stops the movement
            }
        }
    }
}

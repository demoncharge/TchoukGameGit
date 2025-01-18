// PlayerController.cs
using UnityEngine;

public class Position : MonoBehaviour
{
    public Transform centerPoint; // Center of the semicircle
    public float radius = 5f;     // Radius of the semicircle
    public float speed = 2f;      // Movement speed

    private float angle = 0f;     // Current angle of the player

    void Update()
    {
        // Handle player movement along the semicircle
        float horizontalInput = Input.GetAxis("Horizontal");
        angle -= horizontalInput * speed * Time.deltaTime; // Adjust angle based on input

        // Clamp the angle to stay within the semicircle (e.g., -90 to 90 degrees)
        angle = Mathf.Clamp(angle, -90f, 90f);

        // Calculate the new position on the semicircle
        float x = centerPoint.position.x + radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        float y = centerPoint.position.y + radius * Mathf.Sin(angle * Mathf.Deg2Rad);

        // Update player position
        transform.position = new Vector3(x, y, 0f);
    }
}

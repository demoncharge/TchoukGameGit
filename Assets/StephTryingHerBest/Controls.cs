using UnityEngine;

public class Controls : MonoBehaviour
{
    public float moveSpeed = 5f;      // Movement speed
    private Rigidbody2D rb;            // Rigidbody component

    private Vector3 movement;        // Store movement input

    void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input from WASD or arrow keys
        movement.x = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right
        movement.y = Input.GetAxisRaw("Vertical");   // W/S or Up/Down
    }

    void FixedUpdate()
    {
        // Move the Rigidbody
        rb.linearVelocity = movement.normalized * moveSpeed;
    }
}

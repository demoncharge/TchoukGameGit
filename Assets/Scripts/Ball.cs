using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject Frame;
    public GameObject ball;
    public GameObject camera;
    public GameObject targetPositionObject; // Reference to the empty child object
    public float speed = 3f;
    public float bounceSpeed = 3f;
    public float stopDistance = 1.5f;
    public bool movetowardsframe = true;
    public float minScale = 0.5f;  // Minimum scale when close to the Frame
    public float maxScale = 1.5f;
    public float position = 0;
    public GameObject defender;
    public GameObject opponent;
    private Defender defendercomponent;
    private Opponent opponentcomponent;
    private bool isBallMovingToTarget = false;
    private Vector3 launchDirection;
    
    private Rigidbody2D rb; // Reference to Rigidbody2D

    void Start()
    {
        if (targetPositionObject == null)
        {
            Debug.LogError("Target Position Object is not assigned!");
        }

        // Get the Rigidbody2D component attached to the ball object
        rb = ball.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component not found on the ball!");
        }
    }

    void Update()
    {
        // Get the components for defender and opponent
        defendercomponent = defender.GetComponent<Defender>();
        opponentcomponent = opponent.GetComponent<Opponent>();

        // Handle camera position based on the angle comparison
        if (defendercomponent.Angle > opponentcomponent.shotangle + 5)
        {
            camera.transform.position = new Vector3(-5, -3, 0);
        }
        else if (defendercomponent.Angle < opponentcomponent.shotangle - 5)
        {
            camera.transform.position = new Vector3(5, -3, 0);
        }
        else
        {
            camera.transform.position = new Vector3(0, -3, 0);
        }

        // If the ball is not a child of anything, proceed with movement logic
        if (transform.parent == null)
        {
            if (movetowardsframe)
            {
                // If "E" key is pressed and the ball is not moving to the target
                if (Input.GetKey(KeyCode.E) && !isBallMovingToTarget)
                {
                    // Move the ball towards the target position object
                    Debug.Log("E Key Pressed: Moving towards target position.");
                    transform.position = Vector3.MoveTowards(transform.position, targetPositionObject.transform.position, speed * Time.deltaTime);
                }

                // After the ball reaches the target position, apply the force to launch it
                if (!isBallMovingToTarget && Vector3.Distance(transform.position, targetPositionObject.transform.position) <= stopDistance)
                {
                    // Set the ball's launch direction
                    launchDirection = targetPositionObject.transform.position - transform.position;
                    launchDirection.Normalize(); // Ensure it's a unit vector
                    LaunchBall(launchDirection);

                    // Set the flag to indicate that the ball should be launched
                    isBallMovingToTarget = true;
                }
                else if (!Input.GetKey(KeyCode.E))
                {
                    // If "E" key is not pressed, move the ball towards the Frame position
                    transform.position = Vector3.MoveTowards(transform.position, Frame.transform.position, speed * Time.deltaTime);

                    if (Vector3.Distance(transform.position, Frame.transform.position) <= stopDistance)
                    {
                        movetowardsframe = false;  // Start bouncing away from the frame if needed
                    }
                }
            }
            else
            {
                // Logic for bouncing the ball towards the camera when not moving to the frame
                transform.position = Vector3.MoveTowards(transform.position, camera.transform.position, bounceSpeed * Time.deltaTime);
            }
        }
    }

    void LaunchBall(Vector3 direction)
    {
        // Apply the launch direction to the ball's Rigidbody2D
        if (rb != null)
        {
            // Set the velocity to launch the ball in the opposite direction of the target position
            rb.linearVelocity = new Vector2(-direction.x, -direction.y) * speed; // Use Rigidbody2D velocity
        }
        else
        {
            Debug.LogError("Rigidbody2D component not found on the ball!");
        }

        // Reset movement flags to ensure it doesn't keep moving towards the target
        movetowardsframe = false;
        isBallMovingToTarget = false;

        // Optionally, add more functionality like applying a spin or rotation effect
    }
}

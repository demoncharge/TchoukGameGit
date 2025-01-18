using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject Frame;
    public GameObject ball;
    public GameObject camera;
    public GameObject targetPositionObject;
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
    public bool canmove = true;
    
    private Rigidbody2D rb;

    void Start()
    {
        if (targetPositionObject == null)
        {
            Debug.LogError("Target Position Object is not assigned!");
        }

        rb = ball.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component not found on the ball!");
        }
    }

    void Update()
    {
        defendercomponent = defender.GetComponent<Defender>();
        opponentcomponent = opponent.GetComponent<Opponent>();

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

        if (transform.parent == null)
        {
            if (movetowardsframe)
            {
                if (Input.GetKey(KeyCode.E) && !isBallMovingToTarget)
                {
                    Debug.Log("E Key Pressed: Moving towards target position.");
                    transform.position = Vector3.MoveTowards(transform.position, targetPositionObject.transform.position, speed * Time.deltaTime);
                }

                if (!isBallMovingToTarget && Vector3.Distance(transform.position, targetPositionObject.transform.position) <= stopDistance)
                {
                    launchDirection = targetPositionObject.transform.position - transform.position;
                    launchDirection.Normalize(); // Ensure it's a unit vector
                    LaunchBall(launchDirection);

                    isBallMovingToTarget = true;
                }
                else if (!Input.GetKey(KeyCode.E))
                {

                    transform.position = Vector3.MoveTowards(transform.position, Frame.transform.position, speed * Time.deltaTime);

                    if (Vector3.Distance(transform.position, Frame.transform.position) <= stopDistance)
                    {
                        movetowardsframe = false;  // Start bouncing away from the frame if needed
                    }
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, camera.transform.position, bounceSpeed * Time.deltaTime);
            }
        }
        if(transform.position.y == camera.transform.position.y){
            canmove = false;
        }
    }

    void LaunchBall(Vector3 direction)
    {
        if (rb != null)
        {
            rb.velocity = new Vector2(-direction.x, -direction.y) * speed;
        }
        else
        {
            Debug.LogError("Rigidbody2D component not found on the ball!");
        }

        movetowardsframe = false;
        isBallMovingToTarget = false;

        // Optionally, add more functionality like applying a spin or rotation effect
    }
}

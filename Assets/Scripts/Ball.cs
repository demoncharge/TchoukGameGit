using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

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
    public bool catched = false;
    public int point = 0;
    public GameObject Camra;
    private StupidCamera camara;
    private float Radius = 8f;
    public GameObject gameObjectSave;
    private GameObjectSave gamesave;
    private int time = 0;
    public GameObject Arm;
    private float RANGLE;
    private bool looking = false;
    private float shotheight;
    public TMP_Text score;

    void Start()
    {
        //score = GetComponent<TMP_Text>();

        if (targetPositionObject == null)
        {
            Debug.LogError("Target Position Object is not assigned!");
        }

        rb = ball.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component not found on the ball!");
        }
        RANGLE = Random.Range(1f,10f);
        shotheight = Random.Range(0.1f,3f);
    }

    void Update()
    {
        defendercomponent = defender.GetComponent<Defender>();
        opponentcomponent = opponent.GetComponent<Opponent>();
        gamesave = gameObjectSave.GetComponent<GameObjectSave>();
        camara = Camra.GetComponent<StupidCamera>();

        if (defendercomponent.Angle > opponentcomponent.shotangle + 5)
        {
            float Angle = camara.Angle - 20f;
            Vector3 CamraPos = new Vector3((float) Radius * Mathf.Sin(Angle * (Mathf.PI/180)), (float) Radius * Mathf.Cos(Angle * (Mathf.PI/180)), shotheight);
            camera.transform.position = new Vector3(-CamraPos.y, CamraPos.z, -CamraPos.x);
        }
        else if (defendercomponent.Angle < opponentcomponent.shotangle - 5)
        {
            float Angle = camara.Angle + 20f;
            Vector3 CamraPos = new Vector3((float) Radius * Mathf.Sin(Angle * (Mathf.PI/180)), (float) Radius * Mathf.Cos(Angle * (Mathf.PI/180)), shotheight);
            camera.transform.position = new Vector3(-CamraPos.y, CamraPos.z, -CamraPos.x);
        }
        else
        {
            float Angle = camara.Angle;
            Vector3 CamraPos = new Vector3((float) Radius * Mathf.Sin(Angle * (Mathf.PI/180)), (float) Radius * Mathf.Cos(Angle * (Mathf.PI/180)), shotheight);
            camera.transform.position = new Vector3(-CamraPos.y, CamraPos.z, -CamraPos.x);
            if (catched != true && movetowardsframe != true){
                point += 1;
                score.text = "Score: " + point.ToString();
                catched = true;
            }
        }

        if (transform.parent == null)
        {
            if (!looking) {
                transform.LookAt(Camra.transform);
                looking = true;
            }
            transform.eulerAngles += new Vector3(0,0,RANGLE);
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
                        canmove = false;
                    }
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, camera.transform.position, bounceSpeed * Time.deltaTime);
            }
        }
        if(transform.position.y == camera.transform.position.y){
            if(point == 3){
                SceneManager.LoadSceneAsync(2);
            }
            else {
                if (time > 50) 
                {
                    transform.parent = Arm.transform;
                    gamesave.ResetGameObjects();
                    RANGLE = Random.Range(1f,10f);
                    shotheight = Random.Range(0.1f,3f);
                    opponentcomponent.shot += 1;
                    canmove = true;
                    catched = false;
                    looking = false;
                    movetowardsframe = true;
                    time = 0;
                    transform.position = new Vector3(5.4921734f, 2.5f, 2.3f);
                }
            }
        }
    }

    void FixedUpdate() 
    {
        if(Mathf.Sqrt(Mathf.Pow(transform.position.x,2)+Mathf.Pow(transform.position.z,2))>=Radius-0.2f){
            if(point == 3){
                SceneManager.LoadSceneAsync(2);
            }
            else{
                if (time > 50) 
                {
                }
                else
                {
                    time += 1;
                }
            }
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
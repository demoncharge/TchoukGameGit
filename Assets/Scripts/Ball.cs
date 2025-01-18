using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Frame;
    public GameObject ball;
    public GameObject camera;
    public float speed = 3f;
    public float bounceSpeed = 3f;  // Speed when bouncing away
    public float stopDistance = 1.5f;
    public bool movetowardsframe = true;
    public float minScale = 0.5f;  // Minimum scale when close to the Frame
    public float maxScale = 1.5f;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, Frame.transform.position);
        if(transform.parent == null){
        
            if(movetowardsframe){
                transform.position = Vector3.MoveTowards(transform.position, Frame.transform.position, speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, Frame.transform.position) <= stopDistance)
                {
                    movetowardsframe = false;  // Start bouncing away
                }
                ScaleBall(distance);
            }
            else{ 
                transform.position = Vector3.MoveTowards(transform.position, camera.transform.position, bounceSpeed * Time.deltaTime);
                ScaleBall(distance);
            }
        }
    }
    void ScaleBall(float distance)
    {
        float maxDistance = Vector3.Distance(Frame.transform.position, camera.transform.position);
        float normalizedDistance = Mathf.Clamp01(distance / maxDistance);

        // Calculate the scale factor using Lerp
        float scale = Mathf.Lerp(minScale, maxScale, normalizedDistance);

        // Apply the new scale to the Ball
        transform.localScale = new Vector3(scale, scale, scale);
    }
}

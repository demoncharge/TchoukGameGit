using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    public float Angle = 90f;
    public float Speed = 30f;
    private Ball ballcomponent;
    public GameObject ball;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("HEL");
    }

    void Update()
    {
        
    }

    // Update is called once per 0.02s
    void FixedUpdate()
    {
        ballcomponent = ball.GetComponent<Ball>();
        if (ballcomponent.canmove){
            if (Input.GetKey(KeyCode.A)) 
            {
                Angle -= (1 * Speed) / 50; 
            }
            
            if (Input.GetKey(KeyCode.D))
            {
                Angle += (1 * Speed) / 50;
            }
        }
    }
}

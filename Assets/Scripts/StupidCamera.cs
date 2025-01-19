using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StupidCamera : MonoBehaviour
{
    public float Angle = 90;
    public float Speed = 30;
    public float Radius = 3.1f;
    private Ball ballcomponent;
    public GameObject ball;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

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
        Angle = Mathf.Clamp(Angle, 30f, 150f);

        Vector3 DefenderPosition = new Vector3((float) Radius * Mathf.Sin(Angle * (Mathf.PI/180)), (float) Radius * Mathf.Cos(Angle * (Mathf.PI/180)), 1.5f);
        transform.position = new Vector3(-DefenderPosition.y, DefenderPosition.z, -DefenderPosition.x);
        transform.eulerAngles = new Vector3(0, 90 - Angle, 0);
    }
}

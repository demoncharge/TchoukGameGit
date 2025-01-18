using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    private float Angle = 45f;
    private float Speed = 1f;


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
        if (Input.GetKey(KeyCode.A)) 
        {
            Angle -= (1 * Speed) / 50; 
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            Angle += (1 * Speed) / 50;
        }
        Debug.Log(Angle);
    }
}

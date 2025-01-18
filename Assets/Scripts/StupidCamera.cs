using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StupidCamera : MonoBehaviour
{
    private float Angle = 90;
    private float Speed = 30;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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

        Vector3 DefenderPosition = new Vector3((float) 3.1*Mathf.Sin(Angle * (Mathf.PI/180)), (float) 3.1*Mathf.Cos(Angle * (Mathf.PI/180)), 1);
        transform.position = new Vector3(-DefenderPosition.y, DefenderPosition.z, -DefenderPosition.x);
        transform.eulerAngles = new Vector3(0, 90-Angle, 0);

    }
}

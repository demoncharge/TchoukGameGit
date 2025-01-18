using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StupidCamera : MonoBehaviour
{
    public float Angle = 90;
    public float Speed = 30;
    public float Radius = 3.1f;
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

        Vector3 DefenderPosition = new Vector3((float) Radius * Mathf.Sin(Angle * (Mathf.PI/180)), (float) Radius * Mathf.Cos(Angle * (Mathf.PI/180)), 1);
        transform.position = new Vector3(-DefenderPosition.y, DefenderPosition.z, -DefenderPosition.x);
        transform.eulerAngles = new Vector3(0, 90-Angle, 0);

    }
}

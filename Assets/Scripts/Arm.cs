using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    public GameObject Frame;
    public GameObject OPS;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(OPS.transform.position.x-Frame.transform.position.x < 1.5f){
            transform.DetachChildren();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent : MonoBehaviour
{
    public GameObject Frame;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x-Frame.transform.position.x < 1.5f){
            transform.DetachChildren();
        }
        transform.position += new Vector3(-1f,0,0f) * Time.deltaTime;
    }
}

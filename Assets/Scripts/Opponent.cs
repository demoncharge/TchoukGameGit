using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent : MonoBehaviour
{
    public GameObject Frame;
    public int shot = 0;
    public float shotangle = 0f;
    public List<float> shootinglist = new List<float>();
    // Start is called before the first frame update
    void Start()
    {
        // Generate 10 random integers between 0 and 3
        for (int i = 0; i < 10; i++)
        {
            float randomNumber = Random.Range(30f,90f);
            shootinglist.Add(randomNumber);
        }
    }

    // Update is called once per frame
    void Update()
    {
        shotangle = shootinglist[shot];
        //Debug.Log(shotangle);
        if(transform.position.x-Frame.transform.position.x < 1.5f){
            transform.DetachChildren();
        }
        transform.position += new Vector3(-1f,0,0f) * Time.deltaTime;
    }
}

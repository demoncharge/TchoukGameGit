using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent : MonoBehaviour
{
    public GameObject Frame;
    public int shot = 0;
    public int shotangle = 0;
    public List<int> shootinglist = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        // Generate 10 random integers between 0 and 3
        for (int i = 0; i < 10; i++)
        {
            int randomNumber = Random.Range(0,4);
            shootinglist.Add(randomNumber);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(shootinglist[shot] == 0){
            shotangle = 0;
        }
        else if(shootinglist[shot] == 1){
            shotangle = 30;
        }
        else if(shootinglist[shot] == 2){
            shotangle = 60;
        }
        else{
            shotangle = 90;
        }
        shotangle = 50;
        if(transform.position.x-Frame.transform.position.x < 1.5f){
            transform.DetachChildren();
        }
        transform.position += new Vector3(-1f,0,0f) * Time.deltaTime;
    }
}

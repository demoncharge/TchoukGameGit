using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Opponent : MonoBehaviour
{
    public GameObject Frame;
    public GameObject Arm;
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
        if (shot < 10) 
        {
            shotangle = shootinglist[shot];
            Arm.transform.eulerAngles = new Vector3(0f,0f,-90f+shotangle);
            transform.position += new Vector3(-1f,0,0f) * Time.deltaTime;
        } else {
            SceneManager.LoadSceneAsync(2);
        }
    }
}

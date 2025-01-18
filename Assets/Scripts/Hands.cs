using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour
{
    private bool HandsHigh = false;
    public float Height = 3.5f;
    public float Speed = 10;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Height += (1*Speed/50);
            Debug.Log("UP");
            Debug.Log(Height);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Height -= (1*Speed/50);
            Debug.Log("DOWN");
        }
        transform.position = new Vector3(transform.position.x, Height, transform.position.z);
        Vector2 a = new Vector2(transform.position.x, transform.position.y);
        Vector2 b = new Vector2(0, 1);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 57 * Mathf.Atan(7 * Height) - 90);
        Debug.Log(Mathf.Tan(Vector2.Distance(a,b)));
    }

    void ChangeSprite(Sprite sprite)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;
    }
}

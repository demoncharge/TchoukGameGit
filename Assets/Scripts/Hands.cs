using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour
{
    public Sprite HandHigh;
    public Sprite HandLow;
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
        }
        if (Input.GetKey(KeyCode.S))
        {
            Height -= (1*Speed/50);
        }
        transform.position = new Vector3(transform.position.x, Height, transform.position.z);
        Vector2 a = new Vector2(transform.position.x, transform.position.y);
        Vector2 b = new Vector2(0, 1);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 57 * Mathf.Atan(7 * Height) - 90);
        if (Height < 0)
        {
            ChangeSprite(HandLow);
        } else 
        {
            ChangeSprite(HandHigh);
        }
    }

    void ChangeSprite(Sprite sprite)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;
    }
}

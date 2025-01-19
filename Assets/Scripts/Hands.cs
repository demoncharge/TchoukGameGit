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
    public float MinHeight = -0.4f; // Minimum height boundary
    public float MaxHeight = 3.0f; // Maximum height boundary

    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Height += (1 * Speed / 50);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Height -= (1 * Speed / 50);
        }

        Height = Mathf.Clamp(Height, MinHeight, MaxHeight);

        transform.position = new Vector3(transform.position.x, Height, transform.position.z);

        if (Height <= MinHeight)
        {
            ChangeSprite(HandLow);
        }
        else
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

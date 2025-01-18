using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour
{
    public Sprite HandLow;
    public Sprite HandHigh;
    private bool HandsHigh = false;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            HandsHigh = true;
            ChangeSprite(HandHigh);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            HandsHigh = false;
            ChangeSprite(HandLow);
        }
    }

    void ChangeSprite(Sprite sprite)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;
    }
}

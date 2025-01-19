using UnityEngine;

public class Spin : MonoBehaviour
{
    public float spinSpeed = 300f; // Speed of the spin in degrees per second

    void Update()
    {
        // Rotate the sprite around its z-axis
        transform.Rotate(0,0, spinSpeed);
    }
}

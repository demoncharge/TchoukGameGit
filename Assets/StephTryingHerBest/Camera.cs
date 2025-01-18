using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Transform net; // Reference to the net's transform
    public float cameraOffsetX = 2f; // Optional offset for camera's X position
    public float cameraOffsetY = 2f; // Optional offset for camera's Y position

    void LateUpdate()
    {
        if (player != null && net != null)
        {
            // Find the midpoint between the player and the net for the camera to focus on
            Vector3 midpoint = (player.position + net.position) / 2;

            // Lock the camera's position to the midpoint, adding optional offsets, and set Z to 0
            Vector3 cameraPosition = new Vector3(midpoint.x + cameraOffsetX, midpoint.y + cameraOffsetY, 0f);
            
            // Move the camera to the calculated position
            transform.position = cameraPosition;

            // Make the camera always face the net
            transform.LookAt(net.position);
        }
    }
}

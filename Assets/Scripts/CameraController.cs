using UnityEngine;

public class CameraFollowY : MonoBehaviour
{
    public Transform player; // Assign your player here in the Inspector
    public float smoothSpeed = 0.125f; // Optional: smooth camera movement
    public float yOffset = 0f; // Optional: offset camera from player

    private Vector3 initialCameraPos;

    void Start()
    {
        initialCameraPos = transform.position; // Store the original camera position
    }

    void LateUpdate()
    {
        // Only update the Y position
        float targetY = player.position.y + yOffset;
        float smoothedY = Mathf.Lerp(transform.position.y, targetY, smoothSpeed);

        transform.position = new Vector3(initialCameraPos.x, smoothedY, initialCameraPos.z);
    }
}
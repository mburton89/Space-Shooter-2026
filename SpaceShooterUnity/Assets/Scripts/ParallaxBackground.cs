using UnityEngine;
public class ParallaxBackground : MonoBehaviour
{
    public Transform cameraTransform; // Drag your Main Camera here
    public float parallaxAmount = 0.5f; // 0 = no movement, 1 = moves with camera. Lower = deeper background feel
    private Vector3 previousCameraPosition;
    void Start()
    {
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
        previousCameraPosition = cameraTransform.position;
    }
    void LateUpdate()
    {
        Vector3 cameraMovement = cameraTransform.position - previousCameraPosition;
        // Move Cybertron at a fraction of the camera's speed
        transform.position += new Vector3(cameraMovement.x * parallaxAmount, cameraMovement.y * parallaxAmount, 0);
        previousCameraPosition = cameraTransform.position;
    }
}
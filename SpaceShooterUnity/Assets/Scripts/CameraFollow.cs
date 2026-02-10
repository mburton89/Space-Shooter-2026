using UnityEngine;

public class CameraFollow : MonoBehaviour

{

    public Transform target;
    private float cameraZPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraZPosition = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.position = new Vector3(target.position.x, target.position.y, cameraZPosition);
        }
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
     
public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private float cameraZPosition;

    void Start()
    {
        cameraZPosition = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            transform.position = new Vector3(target.position.x, target.position.y, cameraZPosition);
        }
    }
}

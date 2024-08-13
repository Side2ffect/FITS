using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float cameraSpeed;
    public Vector3 offset;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 cameraPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, cameraPosition, cameraSpeed);
        transform.position = smoothPosition;
    }
}

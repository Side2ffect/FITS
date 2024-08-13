using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity;
    public float maxClampAngle;
    public float minClampAngle;

    public Transform playerBody;
    float xRotation = 10.0f;

    void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        MouseControl();
    }

    public void MouseControl()
    {
        Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Vector2 mouseMovement = mouseSensitivity * Time.deltaTime * mouseInput;

        xRotation -= mouseMovement.y;
        xRotation = Mathf.Clamp(xRotation, minClampAngle, maxClampAngle); ;

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseMovement.x);
    }
}

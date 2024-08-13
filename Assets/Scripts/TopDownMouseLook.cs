using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMouseLook : MonoBehaviour
{
    public float mouseSensitivity;

    [SerializeField] private Transform playerBody;

    void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Update()
    {
        TopDownMouseControl();
    }
    
    void TopDownMouseControl()
    {
        Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), 0.0f);
        Vector2 mouseMovement = mouseSensitivity * Time.deltaTime * mouseInput;
    
        playerBody.Rotate(Vector3.up * mouseMovement.x);
    }

}

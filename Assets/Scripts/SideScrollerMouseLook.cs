using UnityEngine;

public class SideScrollerMouseLook : MonoBehaviour
{
    public float mouseSensitivity;

    [SerializeField] private Transform playerBody;

    private Camera mainCamera;

    void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Confined;
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        SideScrollMouseControl();   
    }

    private void SideScrollMouseControl()
    {
        Vector2 mouseInput = new Vector2(0.0f, Input.GetAxis("Mouse Y"));
        Vector2 mouseMovement = mouseSensitivity * Time.deltaTime * mouseInput;

        playerBody.Rotate(Vector3.left * mouseMovement.y);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    [SerializeField] private Camera TopDownCamera;
 
    // Update is called once per frame
    private void Update()
    {
        Ray ray = TopDownCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            transform.position = raycastHit.point;
        }
    }

    void ChangeToTopDownAim()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
}

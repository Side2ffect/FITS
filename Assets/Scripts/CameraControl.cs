using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public CameraMode CurrentMode;
    [SerializeField] private GameObject FPSCam;
    [SerializeField] private GameObject TopCam;
    [SerializeField] private GameObject SideCam;
    [SerializeField] private GameObject FirstPersonCanvas;
    [SerializeField] private GameObject TopDownCanvas;
    [SerializeField] private GameObject SideScrollerCanvas;
    [SerializeField] private GameObject TopDownCrossHair;
    [SerializeField] private GameObject SideScrollerCrossHair;
    [SerializeField] private GameObject CliffTesting;
    [SerializeField] private GameObject SideScrollerCollider;
    [SerializeField] private GameObject TopDownCollider;
    private GameObject FPSHolder;
    private GameObject TopDownHolder;
    private GameObject SideScrollerHolder;


    void Start()
    {
        FPSHolder = GameObject.FindWithTag("FPSBlock");
        TopDownHolder = GameObject.FindWithTag("TopDownBlock");
        TopDownHolder.SetActive(false);
        SideScrollerHolder = GameObject.FindWithTag("SideScrollerBlock");
        SideScrollerHolder.SetActive(false);
    }

    void Update()
    {
        CameraSwitch();
    }

    private void CameraSwitch()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DisableAll();

            TopCam.SetActive(true);
            TopDownCanvas.SetActive(true);
            TopDownCrossHair.SetActive(true);
            TopDownCollider.SetActive(true);
            TopDownHolder.SetActive(true);
            CliffTesting.SetActive(true);

            CurrentMode = CameraMode.TopDown;

            //Cursor.lockState = CursorLockMode.Confined;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            DisableAll();

            SideCam.SetActive(true);
            SideScrollerCanvas.SetActive(true);
            SideScrollerCrossHair.SetActive(true);
            SideScrollerCollider.SetActive(true);
            SideScrollerHolder.SetActive(true);
            CliffTesting.SetActive(true);

            CurrentMode = CameraMode.SideScroller;

            //Cursor.lockState = CursorLockMode.Confined;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            DisableAll();
            FPSCam.SetActive(true);
            FPSHolder.SetActive(true);
            CurrentMode = CameraMode.FirstPerson;

            CliffTesting.SetActive(false);
            //Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void DisableAll()
    {
        FPSCam.SetActive(false);
        TopCam.SetActive(false);
        SideCam.SetActive(false);
        FirstPersonCanvas.SetActive(false);
        TopDownCanvas.SetActive(false);
        SideScrollerCanvas.SetActive(false);
        TopDownCrossHair.SetActive(false);
        SideScrollerCrossHair.SetActive(false);
        SideScrollerCollider.SetActive(false);
        TopDownCollider.SetActive(false);
        FPSHolder.SetActive(false);
        TopDownHolder.SetActive(false);
        SideScrollerHolder.SetActive(false);
    }

    public enum CameraMode { FirstPerson, TopDown, SideScroller }
}

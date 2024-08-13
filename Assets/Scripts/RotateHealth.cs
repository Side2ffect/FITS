using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHealth : MonoBehaviour
{
    [SerializeField] private GameObject FPSCam;
    [SerializeField] private GameObject TopCam;
    [SerializeField] private GameObject SideCam;

    // Update is called once per frame
    void Update()
    {
        RotateHeart();
    }

    private void RotateHeart()
    { 
        if (FPSCam.activeSelf)
        {
            transform.rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
        }
        if (TopCam.activeSelf)
        {
            transform.rotation = Quaternion.Euler(-90.0f, 90.0f, 0.0f);
        }
        if (SideCam.activeSelf)
        {
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }
    }
}

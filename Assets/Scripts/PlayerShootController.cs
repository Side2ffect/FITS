using UnityEngine;
using UnityEngine.UI;

public class PlayerShootController : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Text ammoText;
    [SerializeField] private int maxAmmo;
    [SerializeField] private CameraControl cameraControl;
    [SerializeField] private Transform firstPersonCamera;
    [SerializeField] private Transform sideScrollerCrosshair;

    private int currentAmmo
    {
        get { return _currentAmmo; }
        set
        {
            if (value < maxAmmo)
            {
                _currentAmmo = value;
            }
            else if (value > 0)
            {
                _currentAmmo = maxAmmo;
            }
            else
            {
                _currentAmmo = 0;
            }
            ammoText.text = $"{_currentAmmo} / {maxAmmo}";
        }
    }
    private int _currentAmmo;

    void Start()
    {
        currentAmmo = maxAmmo;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (currentAmmo > 0)
        {
            currentAmmo--;
            GameObject tempBullet = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            tempBullet.SetActive(true);
            Vector3 forward = Vector3.zero;
            switch (cameraControl.CurrentMode)
            {
                case CameraControl.CameraMode.FirstPerson:
                    forward = firstPersonCamera.transform.forward;
                    break;
                case CameraControl.CameraMode.TopDown:
                    forward = transform.forward;
                    break;
                case CameraControl.CameraMode.SideScroller:
                    Vector3 temp = new Vector3(transform.position.x, transform.position.y, transform.position.z); ;
                    temp = sideScrollerCrosshair.position - temp;
                    forward = temp;
                    break;
            }
            tempBullet.transform.forward = forward;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AmmoRestore"))
        {
            Destroy(other.gameObject);
            currentAmmo += maxAmmo / 2;
        }
    }
}

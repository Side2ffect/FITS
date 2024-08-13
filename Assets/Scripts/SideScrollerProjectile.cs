using UnityEngine;

public class SideScrollerProjectile : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy hit");
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}

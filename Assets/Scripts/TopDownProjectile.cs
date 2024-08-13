using UnityEngine;

public class TopDownProjectile : MonoBehaviour
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

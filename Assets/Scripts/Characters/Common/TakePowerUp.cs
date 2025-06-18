using UnityEngine;

public class TakePowerUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("PowerUp Taken!");
            Destroy(gameObject);
        }
    }
}

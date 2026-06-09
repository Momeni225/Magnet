using UnityEngine;

public class BallCollector : MonoBehaviour
{

    private BallStorageManager ballStorageManager;

    private void Start()
    {
        ballStorageManager =
            GetComponentInParent<BallStorageManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            ballStorageManager.StoreBall(other.gameObject);
            Collider ballCollider = other.GetComponent<Collider>();
            ballCollider.enabled=false;

            Debug.Log(
                "Stored Ball");
        }
    }
}

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
        if (!other.CompareTag("Collectible"))
            return;

        Collider ballCollider =
            other.GetComponent<Collider>();

        if (ballCollider != null)
        {
            ballCollider.enabled = false;
        }

        Debug.Log(
            "Collect Ball ID : " +
            other.GetInstanceID());

        ballStorageManager.StoreBall(
            other.gameObject);
    }
}
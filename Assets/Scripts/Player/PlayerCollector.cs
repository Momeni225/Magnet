using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    private int collectedBallCount;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Collectible"))
        {
            collectedBallCount++;
            Debug.Log("Collected Ball count "+ collectedBallCount);
            //Destroy(other.gameObject);
        }
    }
}

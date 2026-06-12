using UnityEngine;

public class BallContainerTrigger : MonoBehaviour
{
    [SerializeField]
    private GateCounter gateCounter;
    private void Start()
    {
        if (gateCounter == null)
            gateCounter = GetComponentInParent<GateController>()
                ?.GetComponentInChildren<GateCounter>();

        if (gateCounter == null)
            Debug.LogError("GateCounter not found for " + gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Collectible") || gateCounter == null)
            return;

        gateCounter.AddDeliverBall();
    }
}
using UnityEngine;

public class GateSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject gatePrefab;

    [SerializeField]
    private int gateCount = 5;

    [SerializeField]
    private float distanceBetweenGates = 40f;

    [SerializeField]
    private float firstGateZ = 50f;

    private void Start()
    {
        SpawnGates();
    }

    private void SpawnGates()
    {
        for (int gateIndex = 0;
             gateIndex < gateCount;
             gateIndex++)
        {
            Vector3 spawnPosition =
                new Vector3(
                    0f,
                    0f,
                    firstGateZ +
                    gateIndex *
                    distanceBetweenGates);

            Instantiate(
                gatePrefab,
                spawnPosition,
                Quaternion.identity);
        }
    }
}
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject ballPrefab;

    [SerializeField]
    private Transform[] spawnPoints;

    [SerializeField]
    private int ballsPerRow = 5;

    [SerializeField]
    private float horizontalSpacing = 1f;

    private void Start()
    {
        SpawnRows();
    }

    private void SpawnRows()
    {
        foreach (Transform currentSpawnPoint in spawnPoints)
        {
            SpawnRow(currentSpawnPoint);
        }
    }

    private void SpawnRow(Transform spawnPoint)
    {
        float startX =
            -(ballsPerRow - 1) * horizontalSpacing * 0.5f;

        for (int ballIndex = 0;
             ballIndex < ballsPerRow;
             ballIndex++)
        {
            Vector3 spawnPosition =
                spawnPoint.position;

            spawnPosition.x +=
                startX +
                ballIndex * horizontalSpacing;

            Instantiate(
                ballPrefab,
                spawnPosition,
                Quaternion.identity);
        }
    }
}
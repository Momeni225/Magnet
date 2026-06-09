using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BallSpawner : MonoBehaviour
{
   [SerializeField] private GameObject ballPrefab;
   [SerializeField] private int rawCount=3;
   [SerializeField] private int columnCount=5;
   [SerializeField] private float spacing=1.5f;
    private void Start()
    {
        SpawnBall();
    }
    private void SpawnBall()
    {
        for (int row =0; row < rawCount; row++)
        {
            for (int column=0; column< columnCount; column++)
            {
                Vector3 spawnPosition = transform.position+new Vector3(column*spacing,0f,row*spacing);
                
                Instantiate(ballPrefab,
                spawnPosition,
                Quaternion.identity);
            }
        }
    }
}

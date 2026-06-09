using System.Collections.Generic;
using UnityEngine;

public class BallStorageManager : MonoBehaviour
{

    [SerializeField]
    private Transform ballStorageTransform;

    private List<GameObject> storedBalls =
        new List<GameObject>();

    public void StoreBall(GameObject collectedBall)
    {
        storedBalls.Add(collectedBall);

        collectedBall.transform.SetParent(
            ballStorageTransform);

        int storedBallIndex =
            storedBalls.Count - 1;

        collectedBall.transform.localPosition =
            new Vector3(
                0f,
                0f,
                -storedBallIndex * 0.6f);

        Rigidbody ballRigidBody =
            collectedBall.GetComponent<Rigidbody>();

        if (ballRigidBody != null)
        {
            ballRigidBody.isKinematic = true;
        }
    }

    public int GetStoredBallCount()
    {
        return storedBalls.Count;
    }
    
    public List<GameObject> GetStoredBalls()
    {
        Debug.Log("DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDtroedt balls count"+ storedBalls.Count);
        return storedBalls;
    }
    public void CleaStoredBalls()
    {
        storedBalls.Clear();
    }
}


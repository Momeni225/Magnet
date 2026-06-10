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
        if (storedBalls.Contains(collectedBall))
        {
            Debug.Log(
                "BALL ALREADY STORED : " +
                collectedBall.GetInstanceID());

            return;
        }

        Debug.Log(
            "StoreBall Called For : " +
            collectedBall.name +
            " ID : " +
            collectedBall.GetInstanceID());

        Debug.Log(
            "Before Add : " +
            storedBalls.Count);

        storedBalls.Add(collectedBall);

        Debug.Log(
            "After Add : " +
            storedBalls.Count);

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
        return storedBalls;
    }

    public void ClearStoredBalls()
    {
        storedBalls.Clear();
    }
}
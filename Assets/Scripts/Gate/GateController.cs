using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    [SerializeField]
    private Transform depositPoint;

    [SerializeField]
    private int requiredBallCount = 5;

    [SerializeField]
    private GateCounter gateCounter;

//    [SerializeField]private GameObject gateWall;

    private BallStorageManager ballStorageManager;
    private PlayerMovment playerMovment;
    [SerializeField] Transform leftDoor;
    [SerializeField] Transform rightDoor;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        playerMovment = other.GetComponent<PlayerMovment>();

        ballStorageManager =other.GetComponent<BallStorageManager>();

        //gameManager =FindObjectOfType<GameManager>();

        playerMovment.canMoveForward = false;

        Debug.Log("Player Stopped");

        StartCoroutine(MoveBallsDeposit());
    }

    private IEnumerator MoveBallsDeposit()
    {
        List<GameObject> storedBalls =
            new List<GameObject>(
                ballStorageManager.GetStoredBalls());

        Debug.Log("Move Ball To Deposit Started");

        foreach (GameObject ball in storedBalls)
        {
            ball.transform.SetParent(null);

            ball.transform.position =
                depositPoint.position;

            gateCounter.AddDeliverBall();

            yield return new WaitForSeconds(0.2f);
        }

        ballStorageManager.ClearStoredBalls();

        CheckGateCondition();
    }

    private void CheckGateCondition()
    {
        if (gateCounter.GetDeliverBallCount() >= requiredBallCount)
        {
            OpenGate();
        }
        else
        {
            FailLevel();
        }
    }

    private void OpenGate()
    {
        Debug.Log("Gate Opened");
        leftDoor.position += Vector3.left*2f;
        rightDoor.position+= Vector3.right*2f;
        playerMovment.canMoveForward=true;
    }

    private void FailLevel()
    {
        Debug.Log("GAME OVER");

        //gameManager.ShowGameOverPanel();
    }
}
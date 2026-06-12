using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GateController : MonoBehaviour
{
    [SerializeField]
    private Transform depositPoint;

    [SerializeField]
    private int requiredBallCount = 5;

    [SerializeField]
    private GateCounter gateCounter;

    private BallStorageManager ballStorageManager;
    private PlayerMovment playerMovment;
    private bool hasBeenTriggered;

    [SerializeField] Transform leftDoorPivot;
    [SerializeField] Transform rightDoorPivot;

    private void Start()
    {
        if (gateCounter == null)
            gateCounter = GetComponentInChildren<GateCounter>();

        if (gateCounter == null)
            Debug.LogError("GateCounter not found on " + gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player") || hasBeenTriggered)
            return;

        playerMovment = other.GetComponent<PlayerMovment>();
        ballStorageManager = other.GetComponent<BallStorageManager>();

        if (playerMovment == null || ballStorageManager == null)
        {
            Debug.LogError("Player is missing PlayerMovment or BallStorageManager.");
            return;
        }

        hasBeenTriggered = true;
        playerMovment.canMoveForward = false;
        StartCoroutine(MoveBallsDeposit());
    }

    private IEnumerator MoveBallsDeposit()
    {
        List<GameObject> storedBalls =
            new List<GameObject>(ballStorageManager.GetStoredBalls());

        int depositedBallCount = storedBalls.Count;
        int completedJumps = 0;

        foreach (GameObject ball in storedBalls)
        {
            ball.transform.SetParent(null);

            Collider ballCollider = ball.GetComponent<Collider>();
            if (ballCollider != null)
                ballCollider.enabled = true;

            Rigidbody rb = ball.GetComponent<Rigidbody>();
            if (rb != null)
                rb.isKinematic = true;

            Vector3 randomOffset = new Vector3(
                Random.Range(-1f, 1f),
                0f,
                Random.Range(-1f, 1f));

            Vector3 targetPosition =
                depositPoint.position + randomOffset;

            ball.transform
                .DOJump(targetPosition, 2f, 1, 0.5f)
                .OnComplete(() =>
                {
                    completedJumps++;

                    if (gateCounter != null)
                        gateCounter.AddDeliverBall();
                });

            yield return new WaitForSeconds(0.2f);
        }

        ballStorageManager.ClearStoredBalls();

        while (completedJumps < depositedBallCount)
            yield return null;

        CheckGateCondition(depositedBallCount);
    }

    private void CheckGateCondition(int depositedBallCount)
    {
        if (depositedBallCount >= requiredBallCount)
            OpenGate();
        else
            FailLevel();
    }

    private void OpenGate()
    {
        leftDoorPivot.DORotate(new Vector3(0f, 0f, 90f), 1f);
        rightDoorPivot.DORotate(new Vector3(0f, 0f, -90f), 1f);
        StartCoroutine(EnablePlayerMovement());
    }

    private IEnumerator EnablePlayerMovement()
    {
        yield return new WaitForSeconds(1f);

        if (playerMovment != null)
            playerMovment.canMoveForward = true;
    }

    private void FailLevel()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();

        if (gameManager != null)
            gameManager.ShowGameOverPanel();
        else
            Debug.LogError("GameManager not found — player movement stays disabled.");
    }
}

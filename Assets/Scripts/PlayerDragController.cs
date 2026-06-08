using UnityEngine;

public class PlayerDragController : MonoBehaviour
{

    [SerializeField]
    private float dragSensitivity = 0.02f;

    [SerializeField]
    private float leftBoundary = -13f;

    [SerializeField]
    private float rightBoundary = 13f;

    private Vector3 previousMousePosition;

    private bool isDragging;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            previousMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 currentMousePosition =
                Input.mousePosition;

            float mouseDeltaX =
                currentMousePosition.x -
                previousMousePosition.x;

            Vector3 playerPosition =
                transform.position;

            playerPosition.x +=
                mouseDeltaX * dragSensitivity;

            playerPosition.x =
                Mathf.Clamp(
                    playerPosition.x,
                    leftBoundary,
                    rightBoundary);

            transform.position =
                playerPosition;

            previousMousePosition =
                currentMousePosition;
        }
    }
}


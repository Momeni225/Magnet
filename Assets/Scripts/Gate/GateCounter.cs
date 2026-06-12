using UnityEngine;

public class GateCounter : MonoBehaviour
{
    private int deliverBallCount;

    private void Awake()
    {
        Debug.Log(
            "GateCounter Awake ID = " +
            GetInstanceID());
    }

    private void OnEnable()
    {
        Debug.Log(
            "GateCounter Enable ID = " +
            GetInstanceID());
    }

    public void AddDeliverBall()
    {
        deliverBallCount++;

        Debug.Log(
            "Add Count To ID = " +
            GetInstanceID() +
            " Count = " +
            deliverBallCount);
    }

    public int GetDeliverBallCount()
    {
        Debug.Log(
            "Get Count From ID = " +
            GetInstanceID() +
            " Count = " +
            deliverBallCount);

        return deliverBallCount;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateCounter : MonoBehaviour
{
    private int deliverBallCount;
    public void AddDeliverBall()
    {
        deliverBallCount++;
        Debug.Log("DeliveredBalCount ::"+deliverBallCount);
    }
    public int GetDeliverBallCount()
    {
        return deliverBallCount;
    }
}

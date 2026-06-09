using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
   [SerializeField] private Transform depositPoint;
   private BallStorageManager ballStorageManager;
   [SerializeField]private int requiredBallCount = 5;
    private PlayerMovment playerMovment;
    [SerializeField] private GateCounter gateCounter;
    [SerializeField] private GameObject gateWall;

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player"))
            
            return;

        playerMovment=other.GetComponent<PlayerMovment>();
                ballStorageManager=other.GetComponent<BallStorageManager>();

        playerMovment.canMoveForward=false;
        Debug.Log("Stopppppppppppppeeeeedddddddddddd");
        
       StartCoroutine (MoveBallsDeposit());
       /* if (other.CompareTag("Player"))
        {
            playerMovment=other.GetComponent<PlayerMovment>();
        
        playerMovment.canMoveForward=false;
        Debug.Log("Palyer Stop;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;");
        ballStorageManager=other.GetComponent<BallStorageManager>();
       MoveBallsDeposit();    
            Debug.Log(
                "Player Stopped");
        }*/
    }
    private IEnumerator MoveBallsDeposit()
    {           
       List<GameObject> storedBalls=ballStorageManager.GetStoredBalls();
       Debug.Log("Move Ball to Deposit Started  ;;;;;;;;;;;;;;;;;;;;;;;;");
       foreach(GameObject ball in storedBalls)
        {
            Debug.Log("!!!!!!!!!!!!!!!! Moving"+ball.name );
            ball.transform.SetParent(null);
            ball.transform.position=depositPoint.position;
            gateCounter.AddDeliverBall();
            yield return new WaitForSeconds(0.2f);

        }
        CheckGateCondition();
    
    }
    private void CheckGateCondition()
    {
        if (gateCounter.GetDeliverBallCount() >= requiredBallCount)
        {
            Debug.Log("Gate Oppend :)");
            Destroy(gateWall);
            playerMovment.canMoveForward=true;
          //  GetComponent<Collider>().enabled=false;
          Debug.Log("GateOpen?????????????????????????????");
        }
    }
}


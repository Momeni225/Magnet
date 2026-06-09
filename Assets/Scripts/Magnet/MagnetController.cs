using UnityEngine;

public class MagnetController : MonoBehaviour
{
  
    [SerializeField] private Transform PlayerTransform;
    [SerializeField] private float magnetForce=15f;
    
    private  void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            Rigidbody ballRigidBoady=
            other.GetComponent<Rigidbody>();
            if(ballRigidBoady != null)
            {
                Vector3 directionToPlayer=
                PlayerTransform.position -
                other.transform.position;

                ballRigidBoady.AddForce(directionToPlayer.normalized*
                magnetForce,
                ForceMode.Acceleration);
            }
        }
    }
}


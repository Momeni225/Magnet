
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float forwardMovmentSpeed =5f;
    public float horizontalMovementSpeed=5f;
    public bool canMoveForward=true;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // transform.Translate(Vector3.forward*speed*Time.deltaTime);
       // float horizontalMovement= Input.GetAxis("Horizontal");

        //transform.Translate(Vector3.right*horizontalMovement*sideSpeed*Time.deltaTime);
        if(canMoveForward)
        {
            transform.Translate(Vector3.forward*
            forwardMovmentSpeed*Time.deltaTime);
        }
        Vector3 pos = transform.position;
        pos.x=Mathf.Clamp(pos.x,-8f,8f);
        transform.position=pos;
    }
}


using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float speed =5f;
    public float sideSpeed=5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward*speed*Time.deltaTime);
       // float horizontalMovement= Input.GetAxis("Horizontal");

        //transform.Translate(Vector3.right*horizontalMovement*sideSpeed*Time.deltaTime);
        Vector3 pos = transform.position;
        pos.x=Mathf.Clamp(pos.x,-8f,8f);
        transform.position=pos;
    }
}

using UnityEngine;

public class CameraFollow : MonoBehaviour
{     
      [SerializeField] private Transform PlayerTransform;
      [SerializeField] private  Vector3 cameraOffset;
 private void LateUpdate()
    {
         transform.position=
          PlayerTransform.position+
          cameraOffset;
    }
}

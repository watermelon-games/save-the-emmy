using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolow : MonoBehaviour
{
    public Transform target;
    public Vector3 cameraOffset;
    public float followSpeed = 10f;
    public float xMin = 0;
    Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        Vector3 targetPossition = target.position + cameraOffset;
        Vector3 clampedPosition = new Vector3(Mathf.Clamp(targetPossition.x, xMin, float.MaxValue), targetPossition.y, targetPossition.z);
        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, clampedPosition, ref velocity,
            followSpeed * Time.fixedDeltaTime);
    }
}

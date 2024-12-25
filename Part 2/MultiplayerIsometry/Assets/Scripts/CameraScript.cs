using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
    private float smoothTime = 0.25f;
    private Vector3 currentVelocity = Vector3.zero;

    void Awake() {
        offset = transform.position - target.position;
    }

    private void LateUpdate() {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime);
    }
}

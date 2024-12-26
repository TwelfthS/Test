using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CameraScript : NetworkBehaviour
{
    public Transform mainCamera;
    private Vector3 offset = new Vector3(1f, 0.5f, 2f);
    private float smoothTime = 0.25f;
    private Vector3 currentVelocity = Vector3.zero;

    void Start() {
        if (isLocalPlayer) {
            mainCamera = GameObject.Find("CameraPivot").GetComponent<Transform>();
            // offset = mainCamera.position - transform.position;
        }
    }

    private void LateUpdate() {
        if (isLocalPlayer) {
            Vector3 targetPosition = transform.position + offset;
            mainCamera.position = Vector3.SmoothDamp(mainCamera.position, targetPosition, ref currentVelocity, smoothTime);            
        }
    }
}

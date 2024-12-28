using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerController : NetworkBehaviour
{
    private Rigidbody rb;
    private float speed = 5f;
    private float speedBonus = 0;
    private float speedUpTime = 0;
    private Vector3 input;
    private Matrix4x4 isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
    private bool isSpeedingUp;
    private float rotationSpeed = 90f;
    void Awake() {
        rb = GetComponent<Rigidbody>();
    }
    void Update() {
        if (isLocalPlayer) {
            GatherInput();
            Turn();
            // Look();
        }
    }

    void FixedUpdate() {
        Move();
    }

    void GatherInput() {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
    }

    // void Look() {
    //     if (input != Vector3.zero) {
    //         Vector3 isometricInput = isoMatrix.MultiplyPoint3x4(input);
    //         if (input.x == 0 || input.z == 0) {
    //             isSpeedingUp = true;
    //         } else {
    //             isSpeedingUp = false;
    //             speedUpTime = 0;
    //             speedBonus = 0;
    //         }
    //         transform.rotation = Quaternion.LookRotation(isometricInput, Vector2.up);            
    //     } else {
    //         isSpeedingUp = false;
    //         speedUpTime = 0;
    //         speedBonus = 0;
    //     }
    // }

    void Move() {
        if (isSpeedingUp && speedUpTime < 3f) {
            speedBonus += 2 * Time.deltaTime;
            speedUpTime += Time.deltaTime;
        }
        rb.MovePosition(transform.position + (transform.forward * input.z) * (speed + speedBonus) * Time.deltaTime);
    }

    void Turn() {
        if (input != Vector3.zero) {
            Debug.Log(input);
            transform.Rotate(Vector3.up, input.x * rotationSpeed * Time.deltaTime);
        }
    }
}

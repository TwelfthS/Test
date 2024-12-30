using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerController : NetworkBehaviour
{
    private Rigidbody rb;
    private float currentSpeed;
    private float speedBonus;
    private float accelerationStartTime;
    private Vector3 input;
    private Matrix4x4 isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
    private float defaultSpeed = 10f;
    private float accelerationMaxTime = 3.5f;
    private float pushSpeedDecrease = 10f;
    private float bonusSpeedDecrease = 12f;
    private float speedDecrease = 10f;
    private float bonusSpeedIncrease = 1.5f;
    private float rotationSpeed = 180f;
    private bool isAccelerating = false;
    private bool isMovingBack = false;
    [SyncVar]
    private Vector3 pushDirection;
    [SyncVar]
    private float pushSpeed;
    void Awake() {
        rb = GetComponent<Rigidbody>();
    }
    void Update() {
        if (isLocalPlayer) {
            GatherInput();
        }
    }

    void FixedUpdate() {
        if (isLocalPlayer) {
            Turn();
            Move();            
        }
    }

    void GatherInput() {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
    }

    void Move() {
        if (input.z > 0) {
            isMovingBack = false;
            currentSpeed = defaultSpeed;
            if (!isAccelerating) {
                accelerationStartTime = Time.time;
                isAccelerating = true;
            } else {
                float elapsedTime = Time.time - accelerationStartTime;
                if (elapsedTime < accelerationMaxTime) {
                    speedBonus = elapsedTime * bonusSpeedIncrease;
                }
                currentSpeed += speedBonus;
            }
        } else if (input.z < 0) {
            isAccelerating = false;
            if (speedBonus > 0) {
                speedBonus -= bonusSpeedDecrease * Time.fixedDeltaTime;
            } else {
                isMovingBack = true;
                currentSpeed = defaultSpeed * 0.6f;
            }
        } else {
            isAccelerating = false;
            currentSpeed = Mathf.Max(currentSpeed - speedDecrease * Time.fixedDeltaTime, 0);
        }
        rb.AddForce((transform.forward * (isMovingBack ? -1f : 1f) * currentSpeed + pushDirection * pushSpeed) * Time.fixedDeltaTime, ForceMode.VelocityChange);
        if (pushSpeed > 0) {
            pushSpeed = Mathf.Max(pushSpeed - pushSpeedDecrease * Time.fixedDeltaTime, 0);
        }
    }
    void Turn() {
        if (input != Vector3.zero) {
            transform.Rotate(Vector3.up, input.x * rotationSpeed * Time.deltaTime);
        }
    }
    public void GetPushed(Vector3 pushDirection, float pushSpeed) {
        this.pushDirection = pushDirection;
        this.pushSpeed = pushSpeed;
    }
    [Command]
    public void RpcPlayerSpeed(float speed) {
        currentSpeed = speed;
    }

    private void OnCollisionEnter(Collision collision) {
        if (isLocalPlayer) {
            RpcPlayerSpeed(currentSpeed);
        }
        if (isServer && collision.gameObject.CompareTag("Player")) {
            PlayerController other = collision.gameObject.GetComponent<PlayerController>();
            other.GetPushed(transform.forward, currentSpeed * 1.5f);
        }
    }
}

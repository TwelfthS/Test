using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject parent;
    private float speed = 5;
    public void Launch(Vector2 direction, GameObject parent) {
        // Debug.Log("Bullet: " + direction);
        this.parent = parent;
        rb.velocity = direction.normalized * speed;
        // Debug.Log("velocity: " + rb.velocity);
    }

    public void ChangeDirection() {
        // Debug.Log("turned");
        // rb.velocity *= transform.up;
        Vector2 currentDirection = transform.right;
        Vector2 perpendicularDirection = new Vector2(-currentDirection.y, currentDirection.x);
        float angle = Mathf.Atan2(perpendicularDirection.y, perpendicularDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        rb.velocity = perpendicularDirection.normalized * speed;
    }
}

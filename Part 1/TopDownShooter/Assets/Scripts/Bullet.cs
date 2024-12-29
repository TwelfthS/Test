using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject owner;
    private float speed = 5;
    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Launch(Vector2 direction, GameObject owner) {
        this.owner = owner;
        rb.velocity = direction.normalized * speed;
    }
    public void ChangeDirection() {
        Vector2 currentDirection = transform.right;
        Vector2 perpendicularDirection = new Vector2(-currentDirection.y, currentDirection.x);
        float angle = Mathf.Atan2(perpendicularDirection.y, perpendicularDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        rb.velocity = perpendicularDirection.normalized * speed;
    }
    public GameObject GetOwner() {
        return owner;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Border")) {
            Destroy(this.gameObject);
        }
    }
}

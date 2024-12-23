using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    // public Rigidbody2D rb;
    private float moveSpeed = 2;
    void Update() {
        if (Vector2.Distance(transform.position, player.transform.position) > 3) {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        }
    }
}

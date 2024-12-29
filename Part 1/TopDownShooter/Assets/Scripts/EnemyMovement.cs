using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private FightScript fightScript;
    private float moveSpeed = 2;
    private float shootTimer = 1f;
    private Vector2 sidewaysMovement;
    void Start() {
        fightScript = GetComponent<FightScript>();
    }
    void Update() {
        sidewaysMovement = Vector2.zero;
        if (shootTimer > 0) {
            shootTimer -= Time.deltaTime;
        }
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right);
        if (hit.collider != null) {
            if (hit.collider.gameObject == player && shootTimer <= 0) {
                fightScript.MakeShot();
                shootTimer = 1f;
            } else if (hit.collider.gameObject.CompareTag("Obstacle")) {
                sidewaysMovement = new Vector2(transform.right.y, -transform.right.x * 3);
            }
        }
        if (Vector2.Distance(transform.position, player.transform.position) > 1.5f) {
            transform.position = Vector2.MoveTowards(transform.position, (Vector2)player.transform.position + sidewaysMovement, moveSpeed * Time.deltaTime);
            Vector2 direction = player.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
}

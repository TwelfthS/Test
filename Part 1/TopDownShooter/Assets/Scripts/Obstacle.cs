using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // private void OnTriggerEnter2D(Collider2D other) {
    //     Debug.Log("triggered");
    //     if (other.gameObject.CompareTag("Bullet")) {
    //         Bullet bullet = other.gameObject.GetComponent<Bullet>();
    //         bullet.ChangeDirection();
    //     }
    // }

    private void OnTriggerEnter2D(Collider2D other) {
        // Debug.Log("triggered");
        if (other.gameObject.CompareTag("Bullet")) {
            Bullet bullet = other.gameObject.GetComponent<Bullet>();
            bullet.ChangeDirection();
        }
    }
}

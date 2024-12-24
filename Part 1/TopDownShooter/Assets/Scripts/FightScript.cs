using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    void Update() {
        // if (Input.GetKeyDown(KeyCode.Space)) {
        //     MakeShot();
        // }
    }
    public void MakeShot() {
        Bullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation).GetComponent<Bullet>();
        bullet.Launch(transform.right, this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Bullet")) {
            Bullet bullet = other.gameObject.GetComponent<Bullet>();
            if (bullet.parent != this.gameObject) {
                Defeat();
            }
        }
    }

    public void Defeat() {

    }
}

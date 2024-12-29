using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightScript : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    public void MakeShot() {
        Bullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation).GetComponent<Bullet>();
        bullet.Launch(transform.right, this.gameObject);
    }
    public void AddScoreToWinner(GameObject winner) {
        CharacterInfo winnerInfo = winner.GetComponent<CharacterInfo>();
        if (winnerInfo != null) {
            winnerInfo.AddScore(10);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Bullet")) {
            Bullet bullet = other.gameObject.GetComponent<Bullet>();
            if (bullet.GetOwner() != this.gameObject) {
                AddScoreToWinner(bullet.GetOwner());
                GameSystem.Instance.Restart();
            }
        }
    }
}

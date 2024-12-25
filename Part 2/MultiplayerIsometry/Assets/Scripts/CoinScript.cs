using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public GameSystem gameSystem;
    private bool isCollected = false;
    void Start () {
        gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player") && !isCollected) {
            // Debug.Log("here " + isCollected);
            isCollected = true;
            PlayerScore playerScore = other.gameObject.GetComponent<PlayerScore>();
            playerScore.AddScore(5);
            gameSystem.SpawnCoin();
            Destroy(this.gameObject);
        }
    }
}

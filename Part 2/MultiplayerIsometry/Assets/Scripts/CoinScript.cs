using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CoinScript : NetworkBehaviour
{
    public GameSystem gameSystem;
    private bool isCollected = false;
    void Start () {
        gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
    }
    private void OnTriggerEnter(Collider other) {
        if (isServer && other.gameObject.CompareTag("Player") && !isCollected) {
            // Debug.Log("here");
            isCollected = true;
            PlayerScore playerScore = other.gameObject.GetComponent<PlayerScore>();
            playerScore.AddScore(5);
            gameSystem.SpawnCoin();
            Destroy(this.gameObject);
            NetworkServer.Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CoinScript : NetworkBehaviour
{
    [SerializeField] private GameObject coinMarkerPrefab;
    private GameObject coinMarker;
    void Start() {
        coinMarker = GameObject.Find("CoinMarker");
        if (coinMarker != null) {
            coinMarker.transform.position = new Vector3(transform.position.x, 10, transform.position.z);
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (isServer && other.gameObject.CompareTag("Player")) {
            PlayerScore playerScore = other.gameObject.GetComponent<PlayerScore>();
            playerScore.AddScore(5);
            GameSystem.Instance.SpawnCoin();
            Destroy(this.gameObject);
            NetworkServer.Destroy(this.gameObject);
        }
    }
}

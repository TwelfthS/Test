using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Mirror;

public class GameSystem : NetworkBehaviour
{
    public CoinSpawner lastActivatedSpawner;
    public CoinSpawner[] coinSpawners;
    private float spawnTimeout = 2f;
    private bool hasSpawned = false;
    void Start()
    {
        coinSpawners = FindObjectsOfType<CoinSpawner>();
    }
    void Update()
    {
        if (isServer) {
            if (spawnTimeout > 0) spawnTimeout -= Time.deltaTime;
            if (spawnTimeout <= 0 && !hasSpawned) {
                SpawnCoin();
                hasSpawned = true;
                // spawnTimeout = 5f;
            }            
        }
    }
    // [SyncEvent]
    // public event EventCoinSpawned;
    [Server]
    public void SpawnCoin() {
        // Debug.Log("spawning");
        CoinSpawner[] coinSpawnersFiltered = coinSpawners.Where(x => x != lastActivatedSpawner).ToArray();
        CoinSpawner randomSpawner = coinSpawners[Random.Range(0, coinSpawnersFiltered.Length)];
        GameObject coin = randomSpawner.SpawnCoin();
        lastActivatedSpawner = randomSpawner;
        // Debug.Log(randomSpawner);
        NetworkServer.Spawn(coin);
        // EventCoinSpawned.Invoke();
    }

    // [ClientCallback]
    // private void Update() {
    //     if (!hasAuthority) { return; }

    // }
}

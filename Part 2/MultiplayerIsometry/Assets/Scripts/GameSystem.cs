using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Mirror;
using TMPro;

public class GameSystem : NetworkBehaviour
{
    public static GameSystem Instance {get; private set;}
    private CoinSpawner lastActivatedSpawner;
    private CoinSpawner[] coinSpawners;
    private float spawnTimeout = 2f;
    private bool hasSpawned = false;
    void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(this.gameObject);
        } else {
            Instance = this;
        }
    }
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
            }
        }
    }
    [Server]
    public void SpawnCoin() {
        CoinSpawner[] coinSpawnersFiltered = lastActivatedSpawner == null ? coinSpawners : GetThreeClosestSpawners(lastActivatedSpawner);
        int randomIndex = Random.Range(0, coinSpawnersFiltered.Length);
        CoinSpawner randomSpawner = coinSpawnersFiltered[randomIndex];
        Debug.Log("filtered: " + coinSpawnersFiltered);
        GameObject coin = randomSpawner.SpawnCoin();
        lastActivatedSpawner = randomSpawner;
        NetworkServer.Spawn(coin);
    }

    public CoinSpawner[] GetThreeClosestSpawners(CoinSpawner target) {
        CoinSpawner[] sortedSpawners = coinSpawners.OrderBy(obj => Vector3.Distance(target.gameObject.transform.position, obj.gameObject.transform.position)).ToArray();
        CoinSpawner[] result = sortedSpawners.Skip(4).ToArray();
        return result;
    }

    [ClientRpc]
    public void RpcGameOver() {
        Debug.Log("Game over");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameSystem : MonoBehaviour
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
        if (spawnTimeout > 0) spawnTimeout -= Time.deltaTime;
        if (spawnTimeout <= 0 && !hasSpawned) {
            SpawnCoin();
            hasSpawned = true;
            // spawnTimeout = 5f;
        }
    }
    public void SpawnCoin() {
        CoinSpawner[] coinSpawnersFiltered = coinSpawners.Where(x => x != lastActivatedSpawner).ToArray();
        CoinSpawner randomSpawner = coinSpawners[Random.Range(0, coinSpawnersFiltered.Length)];
        randomSpawner.SpawnCoin();
        lastActivatedSpawner = randomSpawner;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    // private float firstSpawnTimeout = 2f;
    void Start()
    {
        
    }
    // void Update()
    // {
    //     firstSpawnTimeout -= Time.deltaTime;
    //     if (spawnTimeout <= 0) {
    //         SpawnCoin();
    //         spawnTimeout = 5f;
    //     }
    // }

    public GameObject SpawnCoin() {
        GameObject coin = Instantiate(coinPrefab, transform.position, Quaternion.identity);
        return coin;
    }
}

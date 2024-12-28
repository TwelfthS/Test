using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    public GameObject SpawnCoin() {
        GameObject coin = Instantiate(coinPrefab, transform.position, Quaternion.identity);
        return coin;
    }
}

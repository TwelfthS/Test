using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    private Vector3 spawnPoint;
    void Start()
    {
        spawnPoint = transform.position;
    }
    void Update()
    {
        if (transform.position.y < -3f) {
            SpawnPlayer();
        }
    }

    public void SpawnPlayer() {
        transform.position = spawnPoint;
    }
}

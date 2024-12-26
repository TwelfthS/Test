using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetworkManagerCustom : NetworkManager
{
    // public GameObject playerPrefab;
    public Transform[] spawnPoints;
    private int nextIndex = 0;

    // [Server]
    // public void SpawnPlayer(NetworkConnection conn) {

        
    //     NetworkServer.Spawn(playerInstance, conn);
    // }

    public override void OnServerAddPlayer(NetworkConnectionToClient conn) {
        if (nextIndex < 4) {
            Transform spawnPoint = spawnPoints[nextIndex];
            GameObject playerInstance = Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
            NetworkServer.AddPlayerForConnection(conn, playerInstance);
            nextIndex++;
        }
    }
}

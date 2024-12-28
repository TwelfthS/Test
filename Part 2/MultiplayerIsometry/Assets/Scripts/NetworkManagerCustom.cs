using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetworkManagerCustom : NetworkManager
{
    [SerializeField] private Transform[] spawnPoints;
    private int nextIndex = 0;

    public override void OnServerAddPlayer(NetworkConnectionToClient conn) {
        if (nextIndex < 4) {
            Transform spawnPoint = spawnPoints[nextIndex];
            GameObject playerInstance = Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
            NetworkServer.AddPlayerForConnection(conn, playerInstance);
            nextIndex++;
        }
    }
}

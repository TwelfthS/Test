using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;

public class PlayerScore : NetworkBehaviour
{
    [SyncVar]
    public float score = 0;
    public TMP_Text scoreText;
    void Start () {
        if (isLocalPlayer) {
            scoreText = GameObject.Find("PlayerScore").GetComponent<TMP_Text>();
            scoreText.text = "Score: " + score;            
        }
    }
    [Server]
    public void AddScore(float scoreToAdd) {
        // Debug.Log("Im here");
        // if (isLocalPlayer) {
            // Debug.Log("And here");
            score += scoreToAdd;
            
            RpcUpdateScore(score);
        // }
    }

    // [Command]
    // private void CmdUpdateScore(float updatedScore) {
    //     score = updatedScore;
    //     RpcUpdateScore(updatedScore);
    // }

    [ClientRpc]
    private void RpcUpdateScore(float updatedScore) {
        score = updatedScore;
        if (isLocalPlayer) {
            // Debug.Log("In rpc");
            scoreText.text = "Score: " + score;
        }
        if (score >= 100) {
            if (isLocalPlayer) {
                Debug.Log("You won!");
            } else {
                Debug.Log("The other player won!");
            }
        }
    }
}

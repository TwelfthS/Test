using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;

public class PlayerScore : NetworkBehaviour
{
    [SyncVar]
    private float score = 0;
    private TMP_Text scoreText;
    void Start () {
        if (isLocalPlayer) {
            scoreText = GameObject.Find("PlayerScore").GetComponent<TMP_Text>();
            scoreText.text = "Score: " + score;            
        }
    }
    [Server]
    public void AddScore(float scoreToAdd) {
        score += scoreToAdd;
        RpcUpdateScoreText();
        if (score >= 100) {
            GameSystem.Instance.GameOver();
        }
    }

    [ClientRpc]
    private void RpcUpdateScoreText() {
        if (isLocalPlayer) {
            scoreText.text = "Score: " + score;
        }
    }
}

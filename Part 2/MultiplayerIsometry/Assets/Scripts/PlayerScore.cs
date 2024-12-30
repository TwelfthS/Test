using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerScore : NetworkBehaviour
{
    public delegate void ScoreChanged(float score);
    public event ScoreChanged OnScoreChanged;
    [SyncVar]
    private float score = 0;
    public float ScoreValue
    {
        get { return score; }
        set 
        {
            score = value;
            OnScoreChanged?.Invoke(score);
        }
    }
    [Server]
    public void AddScore(float scoreToAdd) {
        ScoreValue += scoreToAdd;
        RpcUpdateScore(ScoreValue);
        if (score >= 100) {
            GameSystem.Instance.RpcGameOver();
        }
    }

    [ClientRpc]
    public void RpcUpdateScore(float changedScore) {
        ScoreValue = changedScore;
    }
}

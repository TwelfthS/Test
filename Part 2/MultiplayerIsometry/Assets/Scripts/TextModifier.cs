using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;

public class TextModifier : NetworkBehaviour
{
    [SerializeField] private PlayerScore playerScore;
    [SerializeField] private TMP_Text scoreText;
    void Start() {
        if (isLocalPlayer) {
            scoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
            playerScore = GetComponent<PlayerScore>();
            playerScore.OnScoreChanged += UpdateScoreText;
        }
    }
    private void OnDisable()
    {
        if (isLocalPlayer) {
            playerScore.OnScoreChanged -= UpdateScoreText;            
        }
    }
    private void UpdateScoreText(float score)
    {
        if (isLocalPlayer) {
            scoreText.text = $"Score: {score}";
        }
    }
}

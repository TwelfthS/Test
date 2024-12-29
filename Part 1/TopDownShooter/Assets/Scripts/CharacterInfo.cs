using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterInfo : MonoBehaviour
{
    private int score;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] private Vector2 spawnPoint;
    public void AddScore(int scoreToAdd) {
        score += scoreToAdd;
        scoreText.text = score.ToString();
    }
    public void Reset() {
        // score = 0;
        // scoreText.text = score.ToString();
        transform.position = spawnPoint;
    }
}

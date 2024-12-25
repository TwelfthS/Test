using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    public float score = 0;
    public TMP_Text scoreText;
    void Start () {
        scoreText.text = "Score: " + score;
    }
    public void AddScore(float scoreToAdd) {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
}

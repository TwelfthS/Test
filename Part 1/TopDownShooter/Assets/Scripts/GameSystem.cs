using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSystem : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public TMP_Text playerScoreText;
    public TMP_Text enemyScoreText;
    public int playerScore;
    public int enemyScore;
    private Vector2 playerSpawnPoint = new Vector2(-8.36f, -4.44f);
    private Vector2 enemySpawnPoint = new Vector2(8.36f, 4.44f);
    void Start() {
        Restart();
    }
    public void Restart() {
        player.transform.position = playerSpawnPoint;
        enemy.transform.position = enemySpawnPoint;
        playerScore = 0;
        enemyScore = 0;
        UpdateScore();
    }

    public void UpdateScore() {
        playerScoreText.text = playerScore.ToString();
        enemyScoreText.text = enemyScore.ToString();
    }
}

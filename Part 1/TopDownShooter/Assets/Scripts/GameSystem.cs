using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSystem : MonoBehaviour
{
    public static GameSystem Instance;
    [SerializeField] private CharacterInfo playerInfo;
    [SerializeField] private CharacterInfo enemyInfo;
    private Bullet[] allBullets;
    void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(this.gameObject);
        } else {
            Instance = this;
        }
    }
    void Start() {
        Restart();
    }
    public void Restart() {
        playerInfo.Reset();
        enemyInfo.Reset();
        allBullets = FindObjectsOfType<Bullet>();
        foreach (Bullet bullet in allBullets) {
            Destroy(bullet.gameObject);
        }
    }
}

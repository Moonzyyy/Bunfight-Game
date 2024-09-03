using System;
using Player;
using UnityEngine;
using World;

public class Coin : MonoBehaviour
{
    [SerializeField] int scoreToAdd = 1;
    PlayerStats playerStats;
    GameManager.GameManager gameManager;
    WorldRow _worldRow;


    private void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        gameManager = FindObjectOfType<GameManager.GameManager>();
        _worldRow = GetComponentInParent<WorldRow>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameManager.hasGameFinished)
        {
            return;
        }
        if (other.CompareTag("Player"))
        {
            playerStats.AddScore(scoreToAdd);
            _worldRow.remainingCoins.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}

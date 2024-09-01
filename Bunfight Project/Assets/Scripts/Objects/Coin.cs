using Player;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] int scoreToAdd = 1;
    PlayerStats playerStats;
    GameManager.GameManager gameManager;


    private void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        gameManager = FindObjectOfType<GameManager.GameManager>();
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
            Destroy(gameObject);
        }
    }
}

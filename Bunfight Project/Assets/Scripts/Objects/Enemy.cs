using Player;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField, Range(1f, 10f)] private int livesToRemove = 1;
    
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
            playerStats.LoseLife(livesToRemove);
            Destroy(gameObject);
        }
    }
}

using Player;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] int scoreToAdd = 1;
    PlayerStats _playerStats;

    private void Start()
    {
        _playerStats = FindObjectOfType<PlayerStats>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _playerStats.AddScore(scoreToAdd);
            Destroy(gameObject);
        }
    }
}

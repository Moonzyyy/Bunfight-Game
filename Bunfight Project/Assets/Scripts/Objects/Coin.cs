using Player;
using UnityEngine;
using World;

public class Coin : MonoBehaviour
{
    [SerializeField] int scoreToAdd = 1;
    PlayerStats _playerStats;
    GameManager.GameManager _gameManager;
    WorldRow _worldRow;


    private void Start()
    {
        _playerStats = FindObjectOfType<PlayerStats>();
        _gameManager = FindObjectOfType<GameManager.GameManager>();
        _worldRow = GetComponentInParent<WorldRow>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_gameManager.hasGameFinished)
        {
            return;
        }
        if (other.CompareTag("Player"))
        {
            _playerStats.AddScore(scoreToAdd);
            _worldRow.remainingCoins.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}

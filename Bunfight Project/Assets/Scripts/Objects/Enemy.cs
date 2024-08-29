using Player;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField, Range(1f, 10f)] private int livesToRemove = 1;
    
    PlayerStats _playerStats;

    private void Start()
    {
        _playerStats = FindObjectOfType<PlayerStats>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _playerStats.LoseLife(livesToRemove);
            Destroy(gameObject);
        }
    }
}

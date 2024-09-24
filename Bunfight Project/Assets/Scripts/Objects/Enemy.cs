using System;
using System.Collections;
using Player;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField, Range(1f, 10f)] private int livesToRemove = 1;
    
    PlayerStats _playerStats;
    
    GameManager.GameManager _gameManager;
    
    Animator _animator;

    private void Start()
    {
        _playerStats = FindObjectOfType<PlayerStats>();
        _gameManager = FindObjectOfType<GameManager.GameManager>();
        _animator = GetComponent<Animator>();
        StartCoroutine(StartEnemyAnimation());
    }

    IEnumerator StartEnemyAnimation()
    {
        float waitTime = Random.Range(0f, 1f);
        yield return new WaitForSeconds(waitTime);
        _animator.SetBool("canEnemySpeak", true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_gameManager.hasGameFinished)
        {
            return;
        }
        if (other.CompareTag("Player"))
        {
            _playerStats.LoseLife(livesToRemove);
            Destroy(gameObject);
        }
    }
}

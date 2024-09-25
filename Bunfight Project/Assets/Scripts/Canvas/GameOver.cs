using Player;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] string gameOverText = "Game Over! You scored ";
    [SerializeField] private TMP_Text gameOverObject;
    GameManager.GameManager _gameManager;
    private bool _hasShownGameOverScoreText;
    
    PlayerStats _playerStats;
    // Start is called before the first frame update
    void Start()
    {
        _playerStats = FindObjectOfType<PlayerStats>();
        _gameManager = FindObjectOfType<GameManager.GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (_hasShownGameOverScoreText) return;
        if (!_gameManager.hasGameFinished) return;
        gameOverObject.text = gameOverText + _playerStats.score;   
        _hasShownGameOverScoreText = true;
    }
}

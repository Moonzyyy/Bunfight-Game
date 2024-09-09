namespace Player
{
    using UnityEngine;

    public class PlayerStats : MonoBehaviour
    {
        public int lives = 3;
        public int score;
        GameManager.GameManager _gameManager;

        private void Start()
        {
            _gameManager = FindObjectOfType<GameManager.GameManager>();
        }

        public void LoseLife(int livesToLose)
        {
            lives -= livesToLose;
            Debug.Log("Lives: " + lives);
            if (lives <= 0)
            {
                GameOver();
            }
        }

        public void AddScore(int scoreToAdd)
        {
            if (_gameManager.hasGameFinished) return;
            score += scoreToAdd;
            Debug.Log("Score: " + score);
        }

        public void RemoveScore(int scoreToRemove)
        {
            var newScore = score - scoreToRemove;
            if (newScore <= 0) return;
            score = newScore;
        }

        public void GameOver()
        {
            _gameManager.hasGameFinished = true;
        }
    }

}

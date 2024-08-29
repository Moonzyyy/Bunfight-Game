namespace Player
{
    using UnityEngine;

    public class PlayerStats : MonoBehaviour
    {
        public int lives = 3;
        public int score;
        GameManager _gameManager;

        private void Start()
        {
            _gameManager = FindObjectOfType<GameManager>();
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

        void GameOver()
        {
            _gameManager.hasGameFinished = true;
        }
    }

}

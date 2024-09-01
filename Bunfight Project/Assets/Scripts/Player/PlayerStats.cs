namespace Player
{
    using UnityEngine;

    public class PlayerStats : MonoBehaviour
    {
        public int lives = 3;
        public int score;
        GameManager.GameManager gameManager;

        private void Start()
        {
            gameManager = FindObjectOfType<GameManager.GameManager>();
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
            if (gameManager.hasGameFinished) return;
            score += scoreToAdd;
            Debug.Log("Score: " + score);
        }

        public void GameOver()
        {
            gameManager.hasGameFinished = true;
        }
    }

}

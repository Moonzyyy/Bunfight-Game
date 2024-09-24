using System.Collections;
using UnityEngine.SceneManagement;

namespace GameManager
{
    using UnityEngine;

    public class GameManager : MonoBehaviour
    {
        [Header("End")]
        public bool hasGameFinished;
        private bool _beginGameEnd;
        [SerializeField, Range(0.1f, 10f)] private float resetTime = 3f;
        public bool destroyObjectsWhenGameEnd;
        [SerializeField] private GameObject gameOverObject;
        [SerializeField, Range(1, 10)] float gameOverTime = 1f;
        
        [Header("Speed")]
        public int speedScore;
        [Range(1, 200)]public int maxSpeedScoreAmount = 100;
        [Range(0.01f, 1f)] public float gameSpeedToAdd = 0.1f;
        
        [Header("Level")]
        public int gameLevel;
        [Range(2, 10)] public int maxLevel;

        [Header("HUD")]
        private HUD _hud;
        
        [Header("Leaderboard")]
        [SerializeField] GameObject leaderboard;
        
        [Header("Scrolling Background")]
        ScrollingBackground _scrollingBackground;
        
        
        [SerializeField] Scene creditsScene;

        private void Start()
        {
            Application.targetFrameRate = 60;
            Time.timeScale = 1;
            _hud = FindObjectOfType<HUD>();
            _scrollingBackground = FindObjectOfType<ScrollingBackground>();
            gameOverObject.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (hasGameFinished && !_beginGameEnd)
            {
                StartCoroutine(GameFinished());
            }

            if (Input.GetKey(KeyCode.R))
            {
                ResetGame();
            }
        }

        public void AddSpeedScore(int amount)
        {
            speedScore += amount;
            if (speedScore >= maxSpeedScoreAmount && gameLevel < maxLevel)
            {
                speedScore = 0;
                float newTime = Time.timeScale + gameSpeedToAdd;
                Time.timeScale = newTime;
                gameLevel++;
                Debug.Log($"Game Level: {gameLevel}");
            }
        }

        public static void ResetGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void OpenCredits()
        {
            SceneManager.LoadScene("Credits");
        }

        IEnumerator GameFinished()
        {
            hasGameFinished = true;
            _scrollingBackground.canScroll = false;
            yield return new WaitForSeconds(gameOverTime);
            DestroyRemainingObjects();
            ShowGameOverUI();
        }

        private void ShowGameOverUI()
        {
            _hud.DisableScoreText();
            gameOverObject.gameObject.SetActive(true);
            leaderboard.SetActive(true);
        }

        private void DestroyRemainingObjects()
        {
            if (destroyObjectsWhenGameEnd)
            {
                GameObject[] objects = GameObject.FindGameObjectsWithTag("WorldObject");
                foreach (var worldObject in objects)
                {
                    Destroy(worldObject.gameObject);
                }
            }
        }
    }
}


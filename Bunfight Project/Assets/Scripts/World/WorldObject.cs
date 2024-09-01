namespace World
{
    using UnityEngine;
    using System.Collections;

    public class WorldObject : MonoBehaviour
    {
        [SerializeField] private bool canMoveWorld;
        
        [SerializeField] private bool canSpawnWorldRow;
        private bool isSpawningWorldRow;
        [SerializeField, Range(-100, -1)] private float worldMoveSpeed = -5f;
        
        
        [Header("WorldRow")]
        [SerializeField] GameObject worldRowPrefab;
        [SerializeField] Vector3 worldRowSpawnPosition;
        [SerializeField, Range(0.1f, 10f)] private float worldRowSpawnTime = 3f;
        
        GameManager.GameManager gameManager;
        
        bool hasGameStarted = false;
        [SerializeField, Range(1, 10)] private float gameStartTime = 1f;

        private void Start()
        {
            gameManager = FindObjectOfType<GameManager.GameManager>();
            StartCoroutine(StartGame());
        }

        IEnumerator StartGame()
        {
            yield return new WaitForSecondsRealtime(gameStartTime);
            hasGameStarted = true;
        }

        private void Update()
        {
            if (gameManager.hasGameFinished || !hasGameStarted)
            {
                return;
            }
            MoveWorld();
            if (!isSpawningWorldRow && canSpawnWorldRow)
            {
                StartCoroutine(SpawnWorldRow());
            }
            else if (gameManager.hasGameFinished && gameManager.destroyObjectsWhenGameEnd)
            {
                StopAllCoroutines();
            }
        }

        void MoveWorld()
        {
            if (!canMoveWorld)
            {
                return;
            }
            transform.position += new Vector3(worldMoveSpeed * Time.deltaTime, 0, 0);
        }

        IEnumerator SpawnWorldRow()
        {
            isSpawningWorldRow = true;
            yield return new WaitForSecondsRealtime(worldRowSpawnTime);
            GameObject newWorldRow = Instantiate(worldRowPrefab, worldRowSpawnPosition, Quaternion.identity);
            newWorldRow.transform.parent = transform;
            isSpawningWorldRow = false;
        }
    }
}


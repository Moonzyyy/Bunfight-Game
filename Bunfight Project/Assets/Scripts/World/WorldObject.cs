namespace World
{
    using UnityEngine;
    using System.Collections;

    public class WorldObject : MonoBehaviour
    {
        [SerializeField] private bool canMoveWorld;
        
        [SerializeField] private bool canSpawnWorldRow;
        private bool _isSpawningWorldRow;
        [SerializeField, Range(-100, -1)] private float worldMoveSpeed = -5f;
        
        
        [Header("WorldRow")]
        [SerializeField] GameObject worldRowPrefab;
        [SerializeField] Vector3 worldRowSpawnPosition;
        
        GameManager _gameManager;

        private void Start()
        {
            _gameManager = FindObjectOfType<GameManager>();
        }

        private void Update()
        {
            if (_gameManager.hasGameFinished) return;
            MoveWorld();
            if (!_isSpawningWorldRow) StartCoroutine(SpawnWorldRow());
        }

        void MoveWorld()
        {
            if (!canMoveWorld) return;
            transform.position += new Vector3(worldMoveSpeed * Time.deltaTime, 0, 0);
        }

        IEnumerator SpawnWorldRow()
        {
            _isSpawningWorldRow = true;
            yield return new WaitForSecondsRealtime(3);
            GameObject newWorldRow = Instantiate(worldRowPrefab, worldRowSpawnPosition, Quaternion.identity);
            newWorldRow.transform.parent = transform;
            _isSpawningWorldRow = false;
        }
    }
}



using System.Collections.Generic;
using Player;
using UnityEngine.Serialization;

namespace World
{
    using UnityEngine;
    using System.Collections;

    public class WorldRow : MonoBehaviour
    {
        [SerializeField] private GameObject[] spawnPoints;

        [SerializeField] private GameObject enemies;
        [SerializeField] private GameObject coins;

        [SerializeField, Range(1, 10)] private float destroyTime = 10;

        private float minYSpawn = -5f;
        float maxYSpawn = 5f;
        
        PlayerStats _playerStats;
        
        [FormerlySerializedAs("_remainingCoins")] public List<GameObject>remainingCoins;
        
        GameManager.GameManager _gameManager;

        private void Start()
        {
            _playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
            _gameManager = FindObjectOfType<GameManager.GameManager>();
            ChangeSpawnPointPosition();
            SpawnObjects();
            StartCoroutine(DestroyRow());
        }

        private void ChangeSpawnPointPosition()
        {
            foreach (GameObject spawnPoint in spawnPoints)
            {
                float spawnPointY = Random.Range(minYSpawn, maxYSpawn);
                spawnPoint.transform.position = new Vector3(spawnPoint.transform.position.x, spawnPointY, 
                    spawnPoint.transform.position.z);
            }
        }

        private void SpawnObjects()
        {
            int enemySpawn = Random.Range(0, spawnPoints.Length);
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                if (i == enemySpawn)
                {
                    GameObject newEnemy = Instantiate(enemies, spawnPoints[i].transform.position, Quaternion.identity);
                    newEnemy.transform.parent = spawnPoints[i].transform;
                }
                else
                {
                    GameObject newCoin = Instantiate(coins, spawnPoints[i].transform.position, Quaternion.identity);
                    newCoin.transform.parent = spawnPoints[i].transform;
                    remainingCoins.Add(newCoin);
                }
            }
        }

        IEnumerator DestroyRow()
        {
            yield return new WaitForSecondsRealtime(destroyTime);
            if (remainingCoins.Count > 0 && !_gameManager.hasGameFinished)
            {
                _playerStats.score -= remainingCoins.Count;
            }
            Destroy(gameObject);
        }
    }

}


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
        [SerializeField] private GameObject[] coins;

        [SerializeField, Range(1, 10)] private float destroyTime = 10;

        private float _minYSpawn = -5f;
        float _maxYSpawn = 5f;
        
        PlayerStats _playerStats;
        
        [FormerlySerializedAs("_remainingCoins")] public List<GameObject>remainingCoins;
        public List<GameObject> remainingGoldCoins;
        
        GameManager.GameManager _gameManager;

        [SerializeField, Range(1, 10)] private int maxGoldCoinNumber = 10;
        [SerializeField, Range(1, 10)] private int goldCoinRemoveAmount = 10;

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
                float spawnPointY = Random.Range(_minYSpawn, _maxYSpawn);
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
                    int newCoinNumber = CoinToSpawn();
                    GameObject newCoin = Instantiate(coins[newCoinNumber], spawnPoints[i].transform.position, Quaternion.identity);
                    newCoin.transform.parent = spawnPoints[i].transform;
                    if (newCoinNumber == 0) remainingCoins.Add(newCoin);
                    else if (newCoinNumber == 1) remainingGoldCoins.Add(newCoin);
                }
            }
        }

        int CoinToSpawn()
        {
            var coinNumber = Random.Range(0, maxGoldCoinNumber + 1);
            if (coinNumber == 5)
            {
                coinNumber = 1;
            }
            else
            {
                coinNumber = 0;
            }
            return coinNumber;
        }

        IEnumerator DestroyRow()
        {
            yield return new WaitForSecondsRealtime(destroyTime);
            if (remainingCoins.Count > 0 && !_gameManager.hasGameFinished)
            {
                _playerStats.RemoveScore(remainingCoins.Count);
            }

            if (remainingGoldCoins.Count > 0 && !_gameManager.hasGameFinished)
            {
                _playerStats.RemoveScore(remainingGoldCoins.Count * goldCoinRemoveAmount);
            }
            Destroy(gameObject);
        }
    }

}

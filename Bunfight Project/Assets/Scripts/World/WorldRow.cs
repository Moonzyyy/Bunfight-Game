
namespace World
{
    using UnityEngine;
    using System.Collections;

    public class WorldRow : MonoBehaviour
    {
        [SerializeField] private GameObject[] spawnPoints;

        [SerializeField] private GameObject enemies;
        [SerializeField] private GameObject coins;

        [SerializeField, Range(1, 10)] private int destroyTime = 10;

        private void Start()
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
                }
            }
            StartCoroutine(DestroyRow());
        }

        IEnumerator DestroyRow()
        {
            yield return new WaitForSecondsRealtime(destroyTime);
            Destroy(gameObject);
        }
    }

}

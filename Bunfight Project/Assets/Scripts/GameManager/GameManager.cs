using System.Collections;
using UnityEngine.SceneManagement;

namespace GameManager
{
    using UnityEngine;

    public class GameManager : MonoBehaviour
    {
        public bool hasGameFinished;
        private bool beginGameEnd;
        [SerializeField, Range(0.1f, 10f)] private float resetTime = 3f;
        public bool destroyObjectsWhenGameEnd;

        private void Update()
        {
            if (hasGameFinished && !beginGameEnd)
            {
                StartCoroutine(GameFinished());
            }

            if (Input.GetKey(KeyCode.R))
            {
                ResetGame();
            }
        }

        public static void ResetGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        IEnumerator GameFinished()
        {
            hasGameFinished = true;
            yield return new WaitForSeconds(1f);
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


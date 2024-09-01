namespace Player
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.InputSystem;
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D rb2d;
        [SerializeField, Range(0.1f, 100f)] private float forceAmount = 5;
        [SerializeField] private float playerMaximumY = 6.00841f;
        [SerializeField] private float playerMinimumY = -5.203222f;
        GameManager.GameManager gameManager;
        PlayerStats playerStats;
        // Start is called before the first frame update
        void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();
            playerStats = GetComponent<PlayerStats>();
            gameManager = FindObjectOfType<GameManager.GameManager>();
        }

        private void Update()
        {
            if (gameManager.hasGameFinished) StartCoroutine(DestroyPlayer());
            if (transform.transform.position.y > playerMaximumY || transform.transform.position.y < playerMinimumY)
            {
                playerStats.lives = 0;
                playerStats.GameOver();
            }
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (gameManager.hasGameFinished)
            {
                return;
            }
            if (context.performed)
            {
                rb2d.AddForce(transform.up * forceAmount, ForceMode2D.Impulse);
            }
        }

        IEnumerator DestroyPlayer()
        {
            yield return new WaitForSeconds(3f);
            Destroy(gameObject);
        }
    }
}


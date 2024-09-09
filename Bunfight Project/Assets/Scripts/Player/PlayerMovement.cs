namespace Player
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.InputSystem;
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D _rb2d;
        [SerializeField, Range(0.1f, 100f)] private float forceAmount = 5;
        [SerializeField] private float playerMaximumY = 6.00841f;
        [SerializeField] private float playerMinimumY = -5.203222f;
        GameManager.GameManager _gameManager;
        PlayerStats _playerStats;
        [SerializeField] private AudioClip jumpSound;
        // Start is called before the first frame update
        void Start()
        {
            _rb2d = GetComponent<Rigidbody2D>();
            _playerStats = GetComponent<PlayerStats>();
            _gameManager = FindObjectOfType<GameManager.GameManager>();
        }

        private void Update()
        {
            if (_gameManager.hasGameFinished) StartCoroutine(DestroyPlayer());
            if (transform.transform.position.y > playerMaximumY || transform.transform.position.y < playerMinimumY)
            {
                _playerStats.lives = 0;
                _playerStats.GameOver();
            }
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (_gameManager.hasGameFinished)
            {
                return;
            }
            if (!context.performed)
            {
                return;
            }
            _rb2d.AddForce(transform.up * forceAmount, ForceMode2D.Impulse);
            if (Camera.main == null)
            {
                return;
            }
            AudioSource.PlayClipAtPoint(jumpSound, Camera.main.transform.position);
        }

        IEnumerator DestroyPlayer()
        {
            yield return new WaitForSeconds(3f);
            Destroy(gameObject);
        }
    }
}


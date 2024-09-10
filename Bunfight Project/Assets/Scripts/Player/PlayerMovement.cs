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
        [SerializeField] bool useOldMovement;
        Camera _playerCamera;
        
        [Header("New Touch Movement")]
        PlayerInput _playerInput;
        private InputAction _touchPosAction;

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            _touchPosAction = _playerInput.actions.FindAction("TouchPosition");
            
        }

        public void OnEnable()
        {
            _touchPosAction.performed += TouchPressed;
        }
        
        public void OnDisable()
        {
            // _touchPosAction.performed -= TouchPressed;
        }

        // Start is called before the first frame update
        void Start()
        {
            _rb2d = GetComponent<Rigidbody2D>();
            _playerStats = GetComponent<PlayerStats>();
            _gameManager = FindObjectOfType<GameManager.GameManager>();
            _playerCamera = Camera.main;
            if (!useOldMovement)
            {
                _rb2d.gravityScale = 0;
            }
        }

        private void Update()
        {
            if (_gameManager.hasGameFinished)
            {
                StartCoroutine(DestroyPlayer());
            }
            PlayerOutOfBounds();
        }

        private void PlayerOutOfBounds()
        {
            if (!useOldMovement)
            {
                return;
            }
            if (transform.transform.position.y > playerMaximumY || transform.transform.position.y < playerMinimumY)
            {
                _playerStats.lives = 0;
                _playerStats.GameOver();
            }
        }

        private void TouchPressed(InputAction.CallbackContext ctx)
        {
            if (useOldMovement)
            {
                return;
            }
            Vector2 touchPosition = _playerCamera.ScreenToWorldPoint(ctx.ReadValue<Vector2>());
            transform.position = new Vector3(transform.position.x, touchPosition.y, transform.position.z);
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


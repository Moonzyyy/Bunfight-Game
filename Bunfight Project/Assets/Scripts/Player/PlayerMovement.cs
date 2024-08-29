using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField, Range(0.1f, 100f)] private float forceAmount = 5;
    GameManager _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _gameManager = FindObjectOfType<GameManager>();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (_gameManager.hasGameFinished) return;
        if (context.performed)
        {
            _rigidbody2D.AddForce(transform.up * forceAmount, ForceMode2D.Impulse);
        }
    }
}

using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField, Range(0.1f, 100f)] private float forceAmount = 5;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _rigidbody2D.AddForce(transform.up * forceAmount, ForceMode2D.Impulse);
        }
    }
}

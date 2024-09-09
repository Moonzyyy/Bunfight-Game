namespace GameManager
{
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class TouchManager : MonoBehaviour
    {
        PlayerInput _playerInput;
        private InputAction _touchPosAction;

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
        }
    }

}

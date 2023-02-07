using UnityEngine;

public class JumpState : PlayerState
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private float _jumpForce;

    private void OnEnable()
    {
        _playerInput.JumpChanged += OnJumpChanged;
    }

    private void OnDisable()
    {
        _playerInput.JumpChanged -= OnJumpChanged;
    }

    private void OnJumpChanged()
    {
        Animator.Play("Jump_AR_Anim");
        Rigidbody.AddForce(Vector3.up * _jumpForce * Time.deltaTime, ForceMode.Impulse);
    }
}

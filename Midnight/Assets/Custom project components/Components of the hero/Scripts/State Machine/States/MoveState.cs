using UnityEngine;

public class MoveState : PlayerState
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private float _normalSpeed;
    [SerializeField] private float _fastSpeed;
    [SerializeField] private Transform _transform;
    

    private Vector3 _movement;
    private float _currentSpeed;
    private float _animatorSpeed;
    private bool _onDirectionChanged;

    private void OnEnable()
    {
        _playerInput.DirectionChanged += OnDirectionChanged;
        _playerInput.RunChanged += OnFastRun;

        _currentSpeed = _normalSpeed;
        _animatorSpeed = Animator.speed;
        _onDirectionChanged = false;
    }

    private void OnDisable()
    {
        _playerInput.DirectionChanged -= OnDirectionChanged;
        _playerInput.RunChanged -= OnFastRun;
    }

    private void FixedUpdate()
    {
        if (_onDirectionChanged)
        {
            _movement = _movement.normalized * _currentSpeed * Time.deltaTime;
            Rigidbody.MovePosition(_transform.position + _movement);

            if (!Animator.GetCurrentAnimatorStateInfo(0).IsName("Jump_AR_Anim"))
            {
                Animator.Play("RunFWD_AR_Anim");
            } 
            
            _onDirectionChanged = false;
        }
    }

    private void OnDirectionChanged(Vector3 direction)
    {
        _movement = direction;
        _onDirectionChanged = true;
    }

    private void OnFastRun(bool isFastRun)
    {
        if (isFastRun)
        {
            _currentSpeed = _fastSpeed;
            Animator.speed += _animatorSpeed / 2;
        }
        else
        {
            _currentSpeed = _normalSpeed;
            Animator.speed = _animatorSpeed;
        }
    }
}

using UnityEngine;
using UnityEngine.UIElements;

public class AimingState : PlayerState
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] Transform _cameraTransform;
    [SerializeField] Transform _pointFromAim;
    [SerializeField] Transform _cameraLocationTransform;

    private void OnEnable()
    {
        _playerInput.AimChanged += Aiming;
    }

    private void OnDisable()
    {
        _playerInput.AimChanged -= Aiming;
    }

    private void Aiming(bool isAim)
    {
        if (isAim)
        {
            _cameraTransform.position = _pointFromAim.position;
        }
        else
        {
            _cameraTransform.position = _cameraLocationTransform.position;
        }
    }
}

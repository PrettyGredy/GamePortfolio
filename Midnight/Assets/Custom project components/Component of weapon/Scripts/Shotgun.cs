using UnityEngine;

public class Shotgun : Weapon
{
    private void OnEnable()
    {
        _playerInput.Shooting += Shoot;
    }

    private void OnDisable()
    {
        _playerInput.Shooting -= Shoot;
    }
}

using UnityEngine;

public class Assault : Weapon
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

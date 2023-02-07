using UnityEngine;
using UnityEngine.Events;

public class Pistol : Weapon
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

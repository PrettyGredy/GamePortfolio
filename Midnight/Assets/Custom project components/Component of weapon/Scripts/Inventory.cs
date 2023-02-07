using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private PlayerInput _playerInput;

    private Weapon _currentWeapon;
    public List<Weapon> Weapons => _weapons; 
    private int _currentWeaponNumber;

    private void OnEnable()
    {
        _playerInput.SwitchedToTheNextWeapon += NextWeapon;
        _playerInput.SwitchedToThePriviosWeapon += PreviosWeapon;
    }

    private void OnDisable()
    {
        _playerInput.SwitchedToTheNextWeapon -= NextWeapon;
        _playerInput.SwitchedToThePriviosWeapon -= PreviosWeapon;
    }

    private void NextWeapon()
    {
        if (_currentWeaponNumber == _weapons.Count - 1)
            _currentWeaponNumber = 0;
        else
            _currentWeaponNumber++;

        ChangeWeapon(_weapons[_currentWeaponNumber]);
    }

    private void PreviosWeapon()
    {
        if (_currentWeaponNumber == 00)
            _currentWeaponNumber = _weapons.Count - 1;
        else
            _currentWeaponNumber--;

        ChangeWeapon(_weapons[_currentWeaponNumber]);
    }

    private void ChangeWeapon(Weapon weapon)
    {
        if (_currentWeapon != null)
        {
            _currentWeapon.gameObject.SetActive(false);
        }

        _currentWeapon = weapon;
        _currentWeapon.gameObject.SetActive(true);
    }
}

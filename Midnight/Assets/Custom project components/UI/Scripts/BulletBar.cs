using UnityEngine;

public class BulletBar : Bar
{
    [SerializeField] private Inventory _inventory;

    private void OnEnable()
    {
        foreach (var weapon in _inventory.Weapons)
        {
            weapon.NumberOfBulletChanged += OnValueChanged;
        }

        Slider.value = 1;
    }

    private void OnDisable()
    {
        foreach (var weapon in _inventory.Weapons)
        {
            weapon.NumberOfBulletChanged -= OnValueChanged;
        }
    }
}

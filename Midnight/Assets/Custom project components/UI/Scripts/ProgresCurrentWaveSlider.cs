using UnityEngine;

public class ProgresCurrentWaveSlider : Bar
{
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        _spawner.EnemyCountChanged += OnValueChanged;
        Slider.value = 0;
    }

    private void OnDisable()
    {
        _spawner.EnemyCountChanged -= OnValueChanged;
    }
}

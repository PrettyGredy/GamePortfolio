using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class ProgresWaveBar : Bar
{
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        _spawner.WaveCountChanged += OnValueChanged;
        Slider.value = 0;
    }

    private void OnDisable()
    {
        _spawner.WaveCountChanged -= OnValueChanged;
    }
}

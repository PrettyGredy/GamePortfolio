using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Spawner _spawner;

    private int _currentHeakth;
    private int _numberDefeatedEnemies;

    public event UnityAction<int, int> HealthChange;
    public event UnityAction Dying;
    public event UnityAction Victoring;

    private void Start()
    {
        _currentHeakth = _health;
    }

    public void TakeDamage(int damage)
    {
        _currentHeakth -= damage;
        HealthChange?.Invoke(_currentHeakth, _health);
        if (_currentHeakth <= 0)
        {
            Dying?.Invoke();
        }
    }

    public void EnemyDefeated()
    {
        _numberDefeatedEnemies++;
        if (_numberDefeatedEnemies >= _spawner.TotalEnemySpawned)
        {
            Victoring?.Invoke();
        }
    }
}

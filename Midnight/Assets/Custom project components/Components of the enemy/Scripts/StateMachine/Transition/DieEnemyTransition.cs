using UnityEngine;

public class DieEnemyTransition : EnemyTransition
{
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        _enemy.Dying += OnDied;
    }

    private void OnDisable()
    {
        _enemy.Dying -= OnDied;
    }

    private void OnDied()
    {
        NeedTransit = true;
    }
}

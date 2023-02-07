using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class DieEnemyState : EnemyState
{
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        Target.EnemyDefeated();
        _animator.Play("Z_FallingBack");
    }

    private void OnDisable()
    {
        Destroy(gameObject);
    }
}

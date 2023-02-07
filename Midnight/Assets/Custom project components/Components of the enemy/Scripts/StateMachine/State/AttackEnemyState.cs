using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AttackEnemyState : EnemyState
{
    [SerializeField] private int _damage;
    [SerializeField] private int _damageVariation;
    [SerializeField] private float _delay;

    private float _lastAttackTime;

    private void Awake()
    {
        _animator= GetComponent<Animator>();
    }

    private void Update()
    {
        if (_lastAttackTime <= 0)
        {
            Attack();
            _lastAttackTime = _delay;
        }

        _lastAttackTime -= Time.deltaTime;
    }

    private void Attack()
    {
        _damage += Random.Range(-_damageVariation, _damageVariation); 
        _animator.Play("Z_Attack");
        Target.TakeDamage(_damage);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RunEnemyState : EnemyState
{
    [SerializeField] private float _speed;

    private void Awake()
    {
        _animator= GetComponent<Animator>();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, _speed * Time.deltaTime);
        transform.LookAt(Target.transform.position);
        _animator.Play("Z_Run_InPlace");
    }
}

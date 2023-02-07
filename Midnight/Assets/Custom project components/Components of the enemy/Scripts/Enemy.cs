using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;

    private Player _target;
    
    public Player Target => _target;
    public event UnityAction Dying;

    public void Init(Player target)
    {
        _target = target;
    }

    public void TakeDamage(int damage)
    {
        if (_health <= 0)
        {
            Dying?.Invoke();
        }
        else
            _health -= damage;
    }
}

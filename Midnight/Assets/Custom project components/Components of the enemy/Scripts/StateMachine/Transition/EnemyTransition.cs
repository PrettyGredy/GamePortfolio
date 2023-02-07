using UnityEngine;

public abstract class EnemyTransition : MonoBehaviour
{
    [SerializeField] private EnemyState _targetState;

    protected Player Target { get; private set; }

    public EnemyState TargetState => _targetState;
    public bool NeedTransit { get; protected set; }

    public void Init(Player target)
    {
        Target = target;
    }

    private void OnEnable()
    {
        NeedTransit = false;
    }
}

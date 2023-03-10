using System.Collections.Generic;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;

public abstract class PlayerState : MonoBehaviour
{
    [SerializeField] private List<PlayerTransition> _transitions;

    protected Rigidbody Rigidbody { get; private set; }
    protected Animator Animator { get; private set; }

    public void Enter(Rigidbody rigidbody, Animator animator)
    {
        if (enabled == false)
        {
            Rigidbody = rigidbody;
            Animator = animator;

            enabled = true;

            foreach (var transition in _transitions)
            {
                transition.enabled = true;
            }
        }
    }

    public void Exit()
    {
        if (enabled == true)
        {
            foreach (var transition in _transitions)
            {
                transition.enabled = false;
            }

            enabled = false;
        }
    }

    public PlayerState GetNextState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit)
            {
                return transition.TargetState;
            }
        }

        return null;
    }
}

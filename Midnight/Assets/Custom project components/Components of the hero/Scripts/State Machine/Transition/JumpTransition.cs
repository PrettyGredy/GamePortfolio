using UnityEngine;

public class JumpTransition : PlayerTransition
{
    public override void Enable()
    {
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            NeedTransit = true;
        }
    }
}

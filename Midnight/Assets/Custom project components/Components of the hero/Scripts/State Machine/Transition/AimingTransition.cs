using UnityEngine;

public class AimingTransition : PlayerTransition
{
    public override void Enable()
    {
    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            NeedTransit = true;
        }
    }
}

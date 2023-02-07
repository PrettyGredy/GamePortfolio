using UnityEngine;

public class MoveTransition : PlayerTransition
{
    public override void Enable()
    {
    }

    private void Update()
    {
        if ((Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) && !Input.GetMouseButton(1))
        {
            NeedTransit = true;
        }
    }
}

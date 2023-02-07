using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public event UnityAction<Vector3> DirectionChanged;
    public event UnityAction JumpChanged;
    public event UnityAction<bool> RunChanged;
    public event UnityAction<bool> AimChanged;
    public event UnityAction SwitchedToTheNextWeapon;
    public event UnityAction SwitchedToThePriviosWeapon;
    public event UnityAction Shooting;

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            DirectionChanged?.Invoke(transform.forward);
        }

        if (Input.GetKey(KeyCode.D))
        {
            DirectionChanged?.Invoke(transform.right);
        }

        if (Input.GetKey(KeyCode.A))
        {
            DirectionChanged?.Invoke(-transform.right);
        }

        if (Input.GetKey(KeyCode.S))
        {
            DirectionChanged?.Invoke(-transform.forward);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpChanged?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            RunChanged?.Invoke(true);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            RunChanged?.Invoke(false);
        }

        if (Input.GetMouseButton(1))
        {
            AimChanged?.Invoke(true);
        }
        else if(Input.GetMouseButtonUp(1))
        {
            AimChanged?.Invoke(false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Shooting?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            SwitchedToTheNextWeapon?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchedToThePriviosWeapon?.Invoke();
        }

    }
}

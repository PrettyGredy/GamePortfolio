using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float _mouseX;
    private float _mouseY;
    private float _xRotation;

    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _sensitivityMouse;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        _mouseX = Input.GetAxis("Mouse X") * _sensitivityMouse * Time.deltaTime;
        _mouseY = Input.GetAxis("Mouse Y") * _sensitivityMouse * Time.deltaTime;

        _xRotation -= _mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        _playerTransform.Rotate(Vector3.up * _mouseX);
    }

}

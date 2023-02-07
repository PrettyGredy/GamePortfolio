using UnityEngine;
using UnityEngine.Events;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected PlayerInput _playerInput;
    [SerializeField] private string _label;
    [SerializeField] private Transform BulletExitPoint;
    [SerializeField] private int NumberOfBullets;
    [SerializeField] private int NumberOfBoth;
    
    
    [SerializeField] private int _damage;
    [SerializeField] private ParticleSystem _muzzleFlash;
    [SerializeField] private ParticleSystem _hittingEnemyEffect;
    [SerializeField] private ParticleSystem _hittingEnvironmentEffect;
    [SerializeField] private float _fireRate;
    [SerializeField] private float _rangeRay;
    [SerializeField] private Camera _camera;

    private RaycastHit _hit;
    private float nextFire;

    public event UnityAction<int, int> NumberOfBulletChanged;
    public event UnityAction<int, int> NumberOfBothChanged;

    private int _currentNumberOfBullets;
    private int _currentNumberOfBoth;

    private void Awake()
    {
        _currentNumberOfBullets = NumberOfBullets;
        _currentNumberOfBoth = NumberOfBoth;
    }

    protected void Shoot()
    {
        if (Time.time > nextFire && _currentNumberOfBullets >= 0)
        {
            nextFire = Time.time + 1f / _fireRate;
            _muzzleFlash.Play();

            if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out _hit, _rangeRay))
            {
                if (_hit.transform.tag == "Enemy")
                {
                    Instantiate(_hittingEnemyEffect, _hit.point, Quaternion.LookRotation(_hit.normal));
                    _hit.transform.GetComponent<Enemy>().TakeDamage(_damage);
                }

                if (_hit.transform.tag == "Environment")
                {
                    Instantiate(_hittingEnvironmentEffect, _hit.point, Quaternion.LookRotation(_hit.normal));
                }
            }

            _currentNumberOfBullets--;
            NumberOfBulletChanged?.Invoke(_currentNumberOfBullets, NumberOfBullets);
        }

        if (_currentNumberOfBoth >= 0 && _currentNumberOfBullets <= 0)
        {
            _currentNumberOfBoth--;
            _currentNumberOfBullets = NumberOfBullets;
            NumberOfBothChanged?.Invoke(_currentNumberOfBoth, NumberOfBoth);
        }
    }
}

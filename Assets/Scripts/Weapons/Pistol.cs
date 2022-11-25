using Assets.CodeBase.Services.Input;
using CodeBase.StaticData;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Pistol : Weapon
{
    [SerializeField] private AudioSource _audioSource;
    private Camera _camera;
    private Vector3 _hitPoint;
    private IInputService _inputService;
    private HeroStaticData _heroData;

    public override void Construct(IInputService inputService, ObjectPool bulletPool, HeroStaticData heroData)
    {
        _heroData = heroData;
        _inputService = inputService;
        _bulletPool = bulletPool;
        _camera = Camera.main;
        _audioSource.clip = _heroData.ShootSound;
    }

    private void Update()
    {
        CreateBullet();
    }

    protected override void CreateBullet()
    {
        if (_inputService.IsTapToScreen())
        {
            Vector2 mousePosition = _inputService.TapPosition;
            if (mousePosition.y < _camera.pixelHeight / 2)
            {
                return;
            }
            Ray ray = _camera.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out var hitInfo, 1000))
            {
                _hitPoint = hitInfo.point;
                GameObject bullet = _bulletPool.GetPooledObject();
                Bullet bulletComponent = bullet.GetComponent<Bullet>();
                bulletComponent.Construct(_heroData.BulletSpeed, _heroData.Damage);
                bullet.transform.position = _firePoint.transform.position;
                bullet.SetActive(true);
                Vector3 direction = (_hitPoint - _firePoint.transform.position).normalized;
                bulletComponent.Fly(direction);
                _audioSource.Play();
            }
        }
    }
}


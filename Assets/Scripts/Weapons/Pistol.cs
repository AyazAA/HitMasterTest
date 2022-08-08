using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Pistol : Weapon
{
    private Camera _camera;
    private AudioSource _shootSound;
    private Vector3 _hitPoint;

    public override void Construct(ObjectPool bulletPool)
    {
        _bulletPool = bulletPool;
        _camera = Camera.main;
        _shootSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        CreateBullet();
    }

    protected override void CreateBullet()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Input.mousePosition;
            if (mousePosition.y < _camera.pixelHeight / 2)
            {
                return;
            }
            Ray ray = _camera.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out var hitInfo, 1000))
            {
                _hitPoint = hitInfo.point;
                GameObject bullet = _bulletPool.GetPooledObject();
                bullet.transform.position = _firePoint.transform.position;
                bullet.SetActive(true);
                Vector3 direction = (_hitPoint - _firePoint.transform.position).normalized;
                bullet.GetComponent<BaseBullet>().Fly(direction);
                _shootSound.Play();
            }
        }
    }
}


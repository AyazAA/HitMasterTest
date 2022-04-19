using UnityEngine;

public abstract class Weapon: MonoBehaviour
{
    [SerializeField] protected GameObject _firePoint;
    protected ObjectPool _bulletPool;

    public abstract void Construct(ObjectPool bulletPool);
    protected abstract void CreateBullet();
}
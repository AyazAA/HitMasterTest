using Assets.CodeBase.Services.Input;
using CodeBase.StaticData;
using UnityEngine;

public abstract class Weapon: MonoBehaviour
{
    [SerializeField] protected GameObject _firePoint;
    protected ObjectPool _bulletPool;

    public abstract void Construct(IInputService inputService, ObjectPool bulletPool, HeroStaticData heroData);
    protected abstract void CreateBullet();
}
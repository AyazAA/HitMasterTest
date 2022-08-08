using UnityEngine;

public abstract class BaseBullet: MonoBehaviour
{
    [SerializeField] protected float _speed;
    [SerializeField] protected float _damage;

    public float Damage => _damage;

    public abstract void Fly(Vector3 direction);
}

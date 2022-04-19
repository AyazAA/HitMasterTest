using UnityEngine;

public abstract class BaseBullet: MonoBehaviour
{
    [SerializeField] protected float _speed;
    public abstract void Fly(Vector3 direction);
}

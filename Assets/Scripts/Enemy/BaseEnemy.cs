using System;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    public event Action Died;
    public event Action<float> HealthChanged;
    protected float _health;
    [SerializeField] protected float _maxHealth;

    protected void DiedInvoke()
    {
        Died?.Invoke();
    }

    protected void HealthChangedInvoke()
    {
        HealthChanged?.Invoke(_health / _maxHealth);
    }
}



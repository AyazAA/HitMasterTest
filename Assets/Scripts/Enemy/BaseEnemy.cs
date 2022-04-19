using System;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    public event Action OnDied;
    public event Action<float, float> OnHealthChanged;
    protected float _health;
    [SerializeField] protected float _maxHealth;

    protected void OnDiedInvoke()
    {
        OnDied?.Invoke();
    }

    protected void OnHealthChangedInvoke()
    {
        OnHealthChanged?.Invoke(_health,_maxHealth);
    }
}



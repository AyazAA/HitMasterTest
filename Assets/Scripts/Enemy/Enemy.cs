using UnityEngine;

public class Enemy: BaseEnemy
{
    [SerializeField] private float damage = 0.35f;

    private void Start()
    {
        _health = _maxHealth;
        OnHealthChangedInvoke();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<BaseBullet>(out var bullet))
        {
            other.gameObject.SetActive(false);
            _health -= damage;
            OnHealthChangedInvoke();
            if (_health <= 0)
            {
                OnDiedInvoke();
                Destroy(transform.gameObject);
            }
        }
    }
}
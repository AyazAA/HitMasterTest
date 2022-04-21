using UnityEngine;

public class Enemy: BaseEnemy
{
    [SerializeField] private float _damage = 0.35f;
    private EnemyRagdoll _enemyRagdoll;
    private CapsuleCollider _capsuleCollider;

    private void Start()
    {
        _enemyRagdoll = GetComponent<EnemyRagdoll>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
        _health = _maxHealth;
        OnHealthChangedInvoke();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<BaseBullet>(out var bullet))
        {
            other.gameObject.SetActive(false);
            _health -= _damage;
            OnHealthChangedInvoke();
            if (_health <= 0)
            {
                OnDiedInvoke();
                _capsuleCollider.enabled = false;
                _enemyRagdoll.ActivateRagdoll();
            }
        }
    }
}

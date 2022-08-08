using UnityEngine;

[RequireComponent(typeof(EnemyRagdoll),(typeof(CapsuleCollider)))]
public class Enemy: BaseEnemy
{
    private EnemyRagdoll _enemyRagdoll;
    private CapsuleCollider _capsuleCollider;

    private void Start()
    {
        _enemyRagdoll = GetComponent<EnemyRagdoll>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
        _health = _maxHealth;
        HealthChangedInvoke();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<BaseBullet>(out var bullet))
        {
            _health -= bullet.Damage;
            HealthChangedInvoke();
            if (_health <= 0)
            {
                DiedInvoke();
                _capsuleCollider.enabled = false;
                _enemyRagdoll.ActivateRagdoll();
            }
        }
    }
}

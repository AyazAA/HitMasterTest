using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyRagdoll: MonoBehaviour
{
    [SerializeField] private EnemyHealthUI _enemyHealthUI;
    private Rigidbody[] _rigidbodiesRagdoll;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbodiesRagdoll = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody bone in _rigidbodiesRagdoll)
        {
            bone.isKinematic = true;
        }
    }

    public void ActivateRagdoll()
    {
        _animator.enabled = false;
        _enemyHealthUI.Hide();
        foreach (Rigidbody bone in _rigidbodiesRagdoll)
        {
            bone.isKinematic = false;
        }
    }
}
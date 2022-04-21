using UnityEngine;

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ActivateRagdoll();
        }
    }

    public void ActivateRagdoll()
    {
        _animator.enabled = false;
        _enemyHealthUI.gameObject.SetActive(false);
        foreach (Rigidbody bone in _rigidbodiesRagdoll)
        {
            bone.isKinematic = false;
        }
    }
}
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : BaseBullet
{
    [SerializeField] private float _returnPoolTime = 2f;
    private Rigidbody _rigidBody;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _speed = 3f;
    }

    public override void Fly(Vector3 direction)
    {
        StartCoroutine(RemoveToPoolAfterTime());
        if (_rigidBody != null)
        {
            _rigidBody.velocity = direction * _speed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
    }

    private IEnumerator RemoveToPoolAfterTime()
    {
        yield return new WaitForSeconds(_returnPoolTime);
        gameObject.SetActive(false);
    }
}

using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidBody;
    private float _speed;
    private float _damage;
    private readonly float _returnPoolTime = 2f;

    public float Damage => _damage;

    public void Construct(float speed, float damage)
    {
        _speed = speed;
        _damage = damage;
    }

    public void Fly(Vector3 direction)
    {
        StartCoroutine(RemoveToPoolAfterTime());
        if (_rigidBody != null)
        {
            _rigidBody.velocity = direction * _speed;
        }
    }

    private void OnTriggerEnter(Collider other) => 
        gameObject.SetActive(false);

    private IEnumerator RemoveToPoolAfterTime()
    {
        yield return new WaitForSeconds(_returnPoolTime);
        gameObject.SetActive(false);
    }
}

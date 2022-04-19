using UnityEngine;

public class Bullet : BaseBullet
{
    private Rigidbody _rigidBody;

    private void OnEnable()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _speed = 3f;
    }

    public override void Fly(Vector3 direction)
    {
        _rigidBody.velocity = direction * _speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
    }
}

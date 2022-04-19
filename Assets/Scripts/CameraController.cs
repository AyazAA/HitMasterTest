using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector3 offset = new Vector3(0f, -2.1f, 5.5f);
    private Transform _target;

    public void Construct(Transform target)
    {
        _target = target;
    }

    private void LateUpdate()
    {
        float currentAngle = transform.eulerAngles.y;
        float desiredAngle = _target.eulerAngles.y;
        float angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.time);

        Quaternion rotation = Quaternion.Euler(0, angle, 0);
        transform.position = _target.position - (rotation * offset);

        transform.LookAt(_target);
    }
}

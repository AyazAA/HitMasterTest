using UnityEngine;

public class MoveByAccelerometer : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 direction;
    
    private void Update()
    {
        direction = Vector3.zero;
        direction.x = Input.acceleration.z;
        if(Input.touchCount > 0)
        {
            foreach (var touch in Input.touches)
            {
                print($"Touch id {touch.fingerId}, Position - {touch.position}, Radius - {touch.radius}, tapCount - {touch.tapCount}");
            }
        }

        if (direction.sqrMagnitude > 1)
        {
            direction = direction.normalized;
        }

        transform.Translate(direction * speed * Time.deltaTime);
    }
}


using UnityEngine;

public class WiggleTester : MonoBehaviour
{
    Rigidbody body;
    [SerializeField] float baseVelocity;
    float baseHeight;
    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        baseHeight = transform.position.y;
    }

    private void LateUpdate()
    {
        float sin = Mathf.Sin( Time.time );
        Vector3 vel = Vector3.zero;
        vel.x = baseVelocity * sin;
        body.velocity = vel;
        Vector3 position = transform.position;
        position.y = baseHeight;
        transform.position = position;
    }
}

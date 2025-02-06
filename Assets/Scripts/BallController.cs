using UnityEngine;

public class BallController : MonoBehaviour
{
    public float initialSpeed = 5f;
    public float maxBounceAngle = 45f;
    public Vector3 initialDirection = new Vector3(1, -1, 0).normalized;

    private Rigidbody rb;
    private Vector3 _velocity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        LaunchBall();
    }

    void LaunchBall()
    {
        _velocity = initialDirection * initialSpeed;
    }

    void OnCollisionEnter(Collision collision)
    {
        print("On Collision Enter " + collision.gameObject.name);
        var platform = collision.gameObject.GetComponent<Platform>();
        if (platform)
        {
            rb.velocity += Vector3.up * initialSpeed;
            float platformWidth = platform.GetComponent<Collider>().bounds.size.x;
            float contactPointX = collision.contacts[0].point.x;
            float platformCenterX = platform.transform.position.x;

            float offset = (contactPointX - platformCenterX) / (platformWidth / 2);
            offset = Mathf.Clamp(offset, -1f, 1f);
            float bounceAngle = offset * maxBounceAngle;
            var bounceDirection = Quaternion.Euler(0, 0, -bounceAngle) * Vector3.up;
            _velocity = bounceDirection.normalized * initialSpeed;
        }
        else
        {
            Vector3 normal = collision.contacts[0].normal;
            _velocity = Vector3.Reflect(_velocity, normal);
            print("Velocity = " + rb.velocity + " Normal = " + normal);
        }
    }

    void Update()
    {
        rb.velocity = _velocity;
        print("velocity = " + rb.velocity);
        if (transform.position.y < -10f)
            ResetBall();
    }

    void ResetBall()
    {
        transform.position = Vector3.zero;
        rb.velocity = Vector3.zero;
        LaunchBall();
    }
}
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _gravity = 3;
    private Vector3 _force;
    private static float KNOCKBACK = 10;

    void OnTriggerEnter(Collider collider)
    {
        print(name + " touches " + collider.name);
        if (collider.GetComponent<Platform>())
            _force = Vector3.up * KNOCKBACK;
        else if (collider.GetComponent<LeftWall>())
            _force = Vector3.right * KNOCKBACK;
        else if (collider.GetComponent<RightWall>())
            _force = Vector3.left * KNOCKBACK;
        else if (collider.GetComponent<Ceil>())
            _force = Vector3.down * KNOCKBACK;

    }

    void Update()
    {
        if (_force.y > 0)
            _force.y -= Time.deltaTime;
        else
            _force.y = 0;
        var knockbackV = _force * Time.deltaTime;//(_energy * 0.005f);
        var gravityV = Vector3.down * (_gravity * Time.deltaTime);
        print("Energy = " + _force + " Knockback = " + knockbackV + " Gravity = " + gravityV);
        transform.localPosition += knockbackV + gravityV;
    }
}

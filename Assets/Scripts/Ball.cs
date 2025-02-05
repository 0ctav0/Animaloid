using UnityEngine;

public class Ball : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        print(name + " touches " + collider.name);

    }
}

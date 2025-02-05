using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField] private float _force = 9.8f;

    void Update()
    {
        var rt = GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, rt.anchoredPosition.y - _force * Time.deltaTime);
    }
}

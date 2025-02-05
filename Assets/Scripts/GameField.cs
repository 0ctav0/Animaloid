using UnityEngine;

public class GameField : MonoBehaviour
{
    [SerializeField] private GameObject _pigPrefab;
    [SerializeField] private int _countX = 10;
    [SerializeField] private int _countY = 15;
    [SerializeField] private int _cellWidth = 100;
    [SerializeField] private int _cellHeight = 100;

    void Start()
    {
        for (var x = 0; x < _countX; x++)
        {
            for (var y = 0; y < _countY; y++)
            {
                var pig = Instantiate(original: _pigPrefab, parent: transform);
                var rt = pig.GetComponent<RectTransform>();
                pig.name = $"Pig {x},{y}";
                rt.anchoredPosition = new Vector2(x * _cellWidth, -y * _cellHeight);
                rt.sizeDelta = new Vector2(_cellWidth, _cellHeight);

            }
        }
    }
}
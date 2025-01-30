using TMPro;
using UnityEngine;

public class TextCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private BaseCollisionHandler _collisionHandler;

    private int _counter = 0;

    private void OnEnable()
    {
        _collisionHandler.ResourseCollecting += Count;
    }

    private void OnDisable()
    {
        _collisionHandler.ResourseCollecting -= Count;
    }

    private void Count(Resource resourse)
    {
        ++_counter;
        _text.text = $"Ресурсы: {_counter}";
    }
}
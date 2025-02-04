using TMPro;
using UnityEngine;

public class TextCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private ResourceStorage _resourceStorage;

    private int _count = 0;

    private void OnEnable()
    {
        _resourceStorage.TextChanging += Count;
    }

    private void OnDisable()
    {
        _resourceStorage.TextChanging -= Count;
    }

    private void Count(int count)
    {
        _count = count + 1;
        _text.text = $"Ресурсы: {_count}";
    }
}
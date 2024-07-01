using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TMP_Text _countText;
    [SerializeField] private float _delay;

    private int _count;
    private bool _isCount;

    private void Start()
    {
        StartCoroutine(TryAddCount());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ToggleCounting();
        }
    }

    private IEnumerator TryAddCount()
    {
        while (true)
        {
            yield return new WaitForSeconds(_delay);

            if (_isCount)
            {
                _count++;
                _countText.text = "Count: " + _count.ToString();
            }
        }
    }

    private void ToggleCounting()
    {
        _isCount = !_isCount;
    }
}
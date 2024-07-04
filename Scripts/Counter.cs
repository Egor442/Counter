using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TMP_Text _countText;
    [SerializeField] private float _delay;

    private Coroutine _coroutine;
    private int _count;
    private bool _isCount;

    private void Start()
    {
        _isCount = true;
        _coroutine = StartCoroutine(TryAddCount());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SwitchCounting();

            TryStart();
            TryStop();
        }
    }

    private IEnumerator TryAddCount()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(_delay);

            _count++;
            _countText.text = "Count: " + _count.ToString();
        }
    }

    private void SwitchCounting()
    {
        _isCount = !_isCount;
    }

    private void TryStop()
    {
        if (_isCount == false)
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
        }
    }

    private void TryStart()
    {
        if (_isCount)
        {
            if (_coroutine != null)
            {
                _coroutine = StartCoroutine(TryAddCount());
            }
        }
    }
}
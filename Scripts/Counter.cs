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
        TryStart();
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
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {                
            _count++;
            _countText.text = $"Count: {_count}";

            yield return wait;
        }
    }

    private void SwitchCounting()
    {
        _isCount = !_isCount;
    }

    private void TryStart()
    {
        if (_isCount)
        {
            _coroutine = StartCoroutine(TryAddCount());
        }
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
}
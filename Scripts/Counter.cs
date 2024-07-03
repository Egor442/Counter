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
                ToggleCounting();
        }
    }

    private IEnumerator TryAddCount()
    {
        while (enabled)
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

    private void Stop()
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
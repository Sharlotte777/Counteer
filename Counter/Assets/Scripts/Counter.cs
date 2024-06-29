using System.Collections;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Counter : MonoBehaviour
{
    private float _counter = 0f;
    private int _numberOfClicks = 0;
    private bool _isCounting = false;
    private Coroutine _countCoroutine;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _numberOfClicks++;

            if (_numberOfClicks % 2 != 0)
            {
                _isCounting = true;
                _countCoroutine = StartCoroutine(CountCoroutine());
            }
            else
            {
                _isCounting = false;
                StopCoroutine(_countCoroutine);
            }
        }
    }

    private IEnumerator CountCoroutine()
    {
        float _waitingTime = 0.5f;
        WaitForSeconds _waiting = new WaitForSeconds(_waitingTime);

        while (_isCounting)
        {
            _counter++;
            Debug.Log(_counter);
            yield return _waiting;
        }
    }
}


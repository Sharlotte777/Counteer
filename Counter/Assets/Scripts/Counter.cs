using System.Collections;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Counter : MonoBehaviour
{
    private float _count = 0f;
    private bool _isCounting = false;
    private Coroutine _coroutine = null;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_coroutine == null)
            {
                _isCounting = true;
                _coroutine = StartCoroutine(Count());
            }
            else
            {
                _isCounting = false;
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }
    }

    private IEnumerator Count()
    {
        float waitingTime = 0.5f;
        WaitForSeconds waiting = new WaitForSeconds(waitingTime);

        while (_isCounting)
        {
            _count++;
            WriteToConsole(_count);
            yield return waiting;
        }
    }

    private void WriteToConsole(float counter)
    {
        Debug.Log(counter);
    }
}


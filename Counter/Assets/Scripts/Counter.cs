using System.Collections;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Counter : MonoBehaviour
{
    private float _counter = 0f;
    private int _numberOfClicks = 0;
    private bool _isCounting = false;
    private Coroutine _count;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _numberOfClicks++;

            if (_numberOfClicks % 2 != 0)
            {
                _isCounting = true;
                _count = StartCoroutine(Count());
            }
            else
            {
                _isCounting = false;
                StopCoroutine(_count);
            }
        }
    }

    private IEnumerator Count()
    {
        float waitingTime = 0.5f;
        WaitForSeconds waiting = new WaitForSeconds(waitingTime);

        while (_isCounting)
        {
            _counter++;
            WriteToConsole(_counter);
            yield return waiting;
        }
    }

    private void WriteToConsole(float counter)
    {
        Debug.Log(counter);
    }
}


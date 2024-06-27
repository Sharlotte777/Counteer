using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private float counter = 0f;
    private int numberOfClicks = 0;
    private bool isCounting = false;
    private Coroutine countCoroutine;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            numberOfClicks++;

            if (numberOfClicks % 2 != 0)
            {
                isCounting = true;
                countCoroutine = StartCoroutine(CountCoroutine());
            }
            else
            {
                isCounting = false;
                StopCoroutine(countCoroutine);
            }
        }
    }

    IEnumerator CountCoroutine()
    {
        while (isCounting)
        {
            counter++;
            Debug.Log(counter);
            yield return new WaitForSeconds(0.5f);
        }
    }
}

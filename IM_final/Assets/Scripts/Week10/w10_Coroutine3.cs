using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class w10_Coroutine3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PrintOddNumber());   // 홀수 출력
        StartCoroutine(PrintEvenNumber());  // 짝수 출력
    }

    IEnumerator PrintOddNumber()
    {
        for (int i = 1; i < 10000; i += 2)
        {
            print(i);
            // 메인 루틴으로 제어권 넘기고 1초 대기
            yield return new WaitForSeconds(1.0f);
        }
    }

    IEnumerator PrintEvenNumber()
    {
        // 메인 루틴으로 제어권 넘기고 0.5초 대기
        yield return new WaitForSeconds(0.5f);

        for (int i = 2; i < 10000; i += 2)
        {
            print(i);
            // 메인 루틴으로 제어권 넘기고 1초 대기
            yield return new WaitForSeconds(1.0f);
        }
    }
}

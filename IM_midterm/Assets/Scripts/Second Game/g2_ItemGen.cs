using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: 아이템을 임의의 위치에 생성한다.
public class g2_ItemGen : MonoBehaviour
{
    public GameObject item1, item2, item3; // 점수를 얻을 수 있는 아이템(칩스, 맥주상자, 샌드위치)
    public GameObject bomb; // 폭탄
    float curTime = 0;  // 경과 시간

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;
        if (curTime > 0.7f)
        {
            GameObject item;    // 생성할 아이템 (폭탄 제외)

            // 세가지 아이템중에 어떤 아이템을 생성할까 선택 (폭탄 제외)
            switch(Random.Range(0, 3))
            {
                case 0:
                    item = item1;
                    break;
                case 1:
                    item = item2;
                    break;
                default:
                    item = item3;
                    break;
            }


            // 오브젝트 생성
            GameObject obj = (Random.Range(0, 10) > 2) ? Instantiate(item) : Instantiate(bomb);

            // 랜덤 위치 지정, 랜덤 각도 지정
            Vector3 objPos = new Vector3(Random.Range(-12.0f, 22.0f), 10, Random.Range(-37.0f, -3.0f));
            obj.transform.position = objPos;
            obj.transform.Rotate(new Vector3(0, Random.Range(0.0f, 360.0f), 0));

            Destroy(obj, 15);    // 15초 후 제거
            curTime = 0;    // 시간 초기화
        }
    }
}

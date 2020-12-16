using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : MonoBehaviour
{
    // 주인공 캐릭터의 Transform 컴포넌트
    Transform playerTr;

    // Start is called before the first frame update
    void Start()
    {
        // 컴포넌트 추출 및 변수 저장
        playerTr = GameObject.FindGameObjectWithTag("PLAYER").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, playerTr.position) <= 0.5f)
        {
            Destroy(gameObject);
            Debug.Log("충돌!");
            GameObject.Find("GameManager").GetComponent<GameManager>().AddItemCount();
        }
    }

   
}

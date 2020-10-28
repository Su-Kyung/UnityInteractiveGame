using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: 발사체 생성기 -> 마우스를 드래그 하여 그 방향과 힘으로 사과 발사
public class g1_Shooter : MonoBehaviour
{
    public GameObject bullet;
    public AudioClip sound;

    Vector3 beginPos;
    AudioSource ads;

    // Start is called before the first frame update
    private void Start()
    {
        ads = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))    // 마우스 누르는 순간 한번만 호출
        {
            beginPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            ads.PlayOneShot(sound);

            Vector3 delta = (Input.mousePosition - beginPos)*0.5f;
            Vector3 force = new Vector3(delta.x, delta.y, Mathf.Abs(delta.y));

            GameObject obj = Instantiate(bullet);
            obj.GetComponent<Rigidbody>().AddForce(force * 5);
        }
    }
}

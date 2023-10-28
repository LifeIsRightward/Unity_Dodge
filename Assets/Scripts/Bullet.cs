using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f; // 탄알 이동 속력
    Rigidbody bulletRigidbody;// 이동에 사용할 리지드바디 컴포넌트

    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>(); // 게임 오브젝트에서 리지드바디 컴포넌트를 찾아 할당
        bulletRigidbody.velocity = transform.forward * speed; // 리지드바디 속도 = 앞쪽 방향 * 속력

        Destroy(gameObject, 3f); //3초 후에 자신의 게임 오브젝트 파괴 -> 탄알이 안맞고 계속 공중을 떠다니게되면, 엄청난 메모리낭비 때문에
        //일정 시간이 지나면 총알이 삭제되게끔 만듦
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //트리거 충돌 시 자동으로 실행되는 메소드(충돌하는 두 물체중 하나라도 is Trigger가 되어있으면 OnTrigger 계열이 실행됨.)
    //현재 불렛(탄알)의 컨트롤러인데, 여기서 온트리거엔터면, other에 담겨있는 정보는 탄알과 부딫힌 녀석의 정보일것이.
    //탄알과 부딫힌 물체의 태그를 봤더니, player 면, 이제 if아래가 실행되는거임 ㅇㅇ
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") {
            PlayerController playerController = other.GetComponent<PlayerController>();//상대방 게임 오브젝트에서 playerController 컴포넌트를 가져옴
            if(playerController != null)// playerController를 가져오는데 성공했다면
            {
                playerController.Die(); // playerController의 Die() 메소드를 실행 
            }
        }

    }
}

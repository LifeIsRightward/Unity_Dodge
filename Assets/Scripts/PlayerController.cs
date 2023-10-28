using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRigidbody; //이동에 사용할 리지드바디 컴포넌트
    public float speed = 8f;// 이동 속도

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();//GetComponent -> 꺽새가로 안에있는 컴포넌트 타입을 찾아오는 메소드
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal"); //수평축의 입력값을 감지
        float zInput = Input.GetAxis("Vertical"); //수직축의 입력값을 감지

        float xspeed = xInput * speed;
        float zspeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xspeed, 0f, zspeed); //새로운 속도 생성
        playerRigidbody.velocity = newVelocity;// Rigidbody에 새로운 속도 할당

        //if(Input.GetKey(KeyCode.UpArrow) == true){ //위쪽 방향키 입력이 감지된 경우, z 방향 힘 주기
        //    playerRigidbody.AddForce(0f, 0f, speed);
        //}
        //if (Input.GetKey(KeyCode.DownArrow) == true){ // 아래쪽 방향키 입력이 감지된 경우, -z 방향 힘 주기
        //    playerRigidbody.AddForce(0f, 0f, -speed);
        //}
        //if (Input.GetKey(KeyCode.RightArrow) == true){ // 오른쪽 방향키 입력이 감지된 경우, x 방향 힘 주기
        //    playerRigidbody.AddForce(speed, 0f, 0f);
        //}
        //if (Input.GetKey(KeyCode.LeftArrow) == true){ // 왼쪽 방향키 입력이 감지된 경우, -x 방향 힘 주기
        //    playerRigidbody.AddForce(-speed, 0f, 0f);
        //}

        if (Input.GetMouseButton(0)) // 앱 용 코드 -> 움직이는거 혹은 데탑용 마우스 ㅇㅇ 키보드가 아니라
        {
            Vector3 screePos = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screePos.z);
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            worldPos.y = 1.0f;
            transform.position = Vector3.MoveTowards(transform.position, worldPos, speed * Time.deltaTime);
        }
    }

    public void Die() {
        gameObject.SetActive(false); // 자신의 게임 오브젝트를 비활성화 시킴

        GameManager gameManager = FindObjectOfType<GameManager>(); // 씬에 존재하는 GameManager 타입의 오브젝트를 찾아서 가져오기
        gameManager.EndGame(); // 가져온 GameManager 오브젝트의 EndGame() 메소드를 실행
    }

}

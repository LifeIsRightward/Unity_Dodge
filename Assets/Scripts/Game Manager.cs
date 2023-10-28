using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI 관련 라이브러리
using UnityEngine.SceneManagement; // 씬 관리 관련 라이브러리 -> 게임이 끝나고 Restart를 할때 씬을 다시 변경하는 그런기능들을 사용할때 사용하는듯(씬에 관련된 기능들이 있음)

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; // 게임오버 시 활성화할 텍스트 게임 오브젝트
    public Text timeText; // 생존 시간을 표시할 텍스트 컴포넌트
    public Text recordText; // 최고 기록을 표시할 텍스트 컴포넌트
    public Button RestartBtn; // 재시작 버튼 
    public Button QuitBtn; // 종료 버튼
    
    public static bool isGameover; // 게임오버 상태

    float surviveTime; // 생존시간
    

    // Start is called before the first frame update
    void Start()
    {
        surviveTime = 0; // 생존 시간 초기화
        isGameover = false; // 게임오버 상태 초기화
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameover) // 게임오버가 아닌 동안
        {
            surviveTime += Time.deltaTime; // 생존 시간 갱신
            //Time.deltaTime은 이전의 Update()함수가 호출되고, 현재 Update()함수가 호출된 이 둘 사이의 시간간격임.
            //그래서 이전 프레임과 현재 프레임의 시간이 되는거임.(아마?)
            timeText.text = "Time: " + (int)surviveTime; // 갱신한 생존시간을 timeText 텍스트 컴포넌트를 이용해 표시
            //int형으로 명시적으로 변환한 이유는 text에 float타입으로 보여서 소수점 아래의 긴 숫자들이 보이게됨. 그래서 Int로 바꿔줌
        }
        /*else
        {
            if (Input.GetKeyDown(KeyCode.R)) // 게임오버 상태에서 R키를 누른 경우
            {
                SceneManager.LoadScene("GameScene"); // GameScene을 로드함
            }
        }*/
    }

    // 현재게임을 게임오버 상태로 변경하는 메서드
    public void EndGame()
    {
        isGameover = true;  //현재 상태를 게임오버 상태로 전환
        gameoverText.SetActive(true); // 게임오버 텍스트 게임오브젝트를 활성화

        float bestTime = PlayerPrefs.GetFloat("BestTime"); // BestTime 키로 저장된 이전까지의 최고 기록 가져오기
        if(surviveTime > bestTime) // 이전까지의 최고기록보다 현재 생존시간이 더 크다면
        {
            bestTime = surviveTime; // 최고 기록값을 현재 생존시간값으로 변경
            PlayerPrefs.SetFloat("BestTime", bestTime); // 변경된 최고기록을 BestTime키로 저장
        }
        recordText.text = "Best Time: " + (int)bestTime; // 최고기록을 recordText 텍스트 컴포넌트를 이용해 표시


    }

}

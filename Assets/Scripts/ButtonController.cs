using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI 관련 라이브러리
using UnityEngine.SceneManagement; // 씬 관리 관련 라이브러리 -> 게임이 끝나고 Restart를 할때 씬을 다시 변경하는 그런기능들을 사용할때 사용하는듯(씬에 관련된 기능들이 있음)
using System;

public class ButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Exit() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;    //pc용 종료 이벤트 -> 유니티 에디터를 종료 시킴
#else
    Application.Quit();
#endif
    }



    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }
}



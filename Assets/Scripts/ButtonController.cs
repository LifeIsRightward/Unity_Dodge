using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI ���� ���̺귯��
using UnityEngine.SceneManagement; // �� ���� ���� ���̺귯�� -> ������ ������ Restart�� �Ҷ� ���� �ٽ� �����ϴ� �׷���ɵ��� ����Ҷ� ����ϴµ�(���� ���õ� ��ɵ��� ����)
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
        UnityEditor.EditorApplication.isPlaying = false;    //pc�� ���� �̺�Ʈ -> ����Ƽ �����͸� ���� ��Ŵ
#else
    Application.Quit();
#endif
    }



    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }
}



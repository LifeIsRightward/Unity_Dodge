using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 60f; //60도
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, rotationSpeed*Time.deltaTime, 0f); //1초에 60프레임씩 돌아 y축이 ㅇㅇ
        //Time.deltaTime 은 여기서 1/60 의 값에 해당됨.
    }
}

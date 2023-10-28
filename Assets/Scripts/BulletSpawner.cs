using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; //생성할 탄알의 원본 프리팹
    public float spawnRateMin = 0.5f; // 최소 생성 주기
    public float spawnRateMax = 3f; // 최대 생성 주기

    Transform target; // 발사할 대상
    float spawnRate; // 생성 주기
    float timeAfterSpawn; // 최근 생성 시점에서 지난 시간

    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f; //최근 생성 이후의 누적 시간을 0으로 초기화
        spawnRate = Random.Range(spawnRateMin, spawnRateMax); // 탄알 생성 간격을 spawnRateMin과 spawnRateMax 사이에서 랜덤으로 지정
        target = FindObjectOfType<PlayerController>().transform; // PlaterController 컴포넌트를 가진 게임 오브젝트를 찾아 조준 대상으로 지정
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isGameover)
        {
            Debug.Log(GameManager.isGameover + "status");
        }else
        {
            timeAfterSpawn += Time.deltaTime; //timeAfterSpwan 갱신
                                              //deltaTime 은 이전프레임에서 현재프레임을 불러오기까지의 경과된 시간을 가져와줌.
            if (timeAfterSpawn >= spawnRate) // 최근 생성 시점에서 부터 누적된 시간이 생성 주기보다 크거나 같다면
            {
                timeAfterSpawn = 0f;// 누적된 시간을 리셋시킴

                // bulletPrefab 복제본을 transform.position 위치와 transform.rotation 회전으로 생성
                GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
                bullet.transform.LookAt(target);
                // 생성된 bullet 게임 오브젝트의 정면 방향이 target을 향하도록 회전

                spawnRate = Random.Range(spawnRateMin, spawnRateMax);
                //다음 생성 간격을 spawnRateMin과 spawnRateMax 사이에서 랜덤으로 지정
            }
        }   
    }
}

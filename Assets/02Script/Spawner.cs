using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //private void Start()
    //{
    //    GameManager.instance.pool.Get(1);
    //}

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            //게임매니저의 인스턴스까지 접근하여 풀링의 함수 호출
            GameManager.instance.pool.Get(1);
        }
    }
}

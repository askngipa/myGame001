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
            //���ӸŴ����� �ν��Ͻ����� �����Ͽ� Ǯ���� �Լ� ȣ��
            GameManager.instance.pool.Get(1);
        }
    }
}

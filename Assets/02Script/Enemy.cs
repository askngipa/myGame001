using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed;
    public Rigidbody2D target;

    bool isLive = true;
    Rigidbody2D rig;
    SpriteRenderer spriter;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if(!isLive)
            return;

        //위치차이 = 타겟위치 - 나의위치
        Vector2 dirVec = target.position - rig.position;
        Vector2 nextVec = dirVec.normalized * Speed * Time.deltaTime;

        //플레이어의 키입력 값을 더한 이동 = 몬스터의 방향값을 더한 이동
        rig.MovePosition(rig.position + nextVec);

        //물리속도가 이동에 영향을 주지 않도록 속도 제거.
        rig.velocity = Vector2.zero;
    }

    private void LateUpdate()
    {
        //목표의 x축과 자신의 x축의 값을 비교하여 작으면 true가 되도록 설정
        spriter.flipX = target.position.x < rig.position.x;
    }

    //OnEnable에서 타겟 변수에 게임매니저를 활용하여 플레이어에 할당
    private void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
    }
}

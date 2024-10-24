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

        //��ġ���� = Ÿ����ġ - ������ġ
        Vector2 dirVec = target.position - rig.position;
        Vector2 nextVec = dirVec.normalized * Speed * Time.deltaTime;

        //�÷��̾��� Ű�Է� ���� ���� �̵� = ������ ���Ⱚ�� ���� �̵�
        rig.MovePosition(rig.position + nextVec);

        //�����ӵ��� �̵��� ������ ���� �ʵ��� �ӵ� ����.
        rig.velocity = Vector2.zero;
    }

    private void LateUpdate()
    {
        //��ǥ�� x��� �ڽ��� x���� ���� ���Ͽ� ������ true�� �ǵ��� ����
        spriter.flipX = target.position.x < rig.position.x;
    }

    //OnEnable���� Ÿ�� ������ ���ӸŴ����� Ȱ���Ͽ� �÷��̾ �Ҵ�
    private void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
    }
}
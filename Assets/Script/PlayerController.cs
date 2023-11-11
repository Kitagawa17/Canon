using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float player_speed; //�v���C���[�̈ړ����x
    bool[] musicNotes = new bool[32];//�擾���Ă鉹����񂱂��ɕێ�
    bool isMove = true;//�ړ����邩���Ȃ�
    void FixedUpdate()
    {
        if (isMove)
        {
            //�ړ������擾
            var h = Input.GetAxis("Horizontal");
            var v = Input.GetAxis("Vertical");
            //��Ɉ�葬�x�ňړ�������
            var velocity = (new Vector3(h, v).normalized) * player_speed * Time.deltaTime;
            transform.position += velocity;

        }
    }
    //�����ƐڐG������Ăяo����Ĕԍ��i�[
    public void MusicNotes_Number(int num)
    {
        musicNotes[num] = true;
        Debug.Log(num);
    }
    public bool IsMove
    {
        set { isMove = value; }
    }
}

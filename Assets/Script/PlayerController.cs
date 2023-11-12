using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float player_speed; //�v���C���[�̈ړ����x
    bool[] musicNotesNumber = new bool[32];//�擾���Ă鉹����񂱂��ɕێ�
    [SerializeField]GameObject[] musicNotesGameObjects = new GameObject[32];//�擾���Ă鉹����񂱂��ɕێ�
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;

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
    //�����ƐڐG������Ăяo����Ĕԍ��i�[,�����\��
    public void MusicNotes_Number(int num)
    {
        audioSource.PlayOneShot(audioClip);
        musicNotesNumber[num] = true;
        musicNotesGameObjects[num].GetComponent<Image>().enabled=true;
        musicNotesGameObjects[num].GetComponent<BoxCollider2D>().enabled=true;
        Debug.Log(num);
    }
    public bool IsMove
    {
        set { isMove = value; }
    }
    public bool[] MusicNotesNumber { get { return musicNotesNumber; } }
}

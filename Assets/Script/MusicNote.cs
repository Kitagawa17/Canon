using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicNote : MonoBehaviour
{
    [SerializeField]int number;//���g�̔ԍ�
    [SerializeField]float followDistance;
    [SerializeField]float followSpeed;
    [SerializeField]float followAccel;
    GameObject player;
    PlayerController playerController;

    Vector3 direction; // �U��΂鎞�̐i�s����
    float speed; // �U��΂鎞�̑���
    [SerializeField] float brake = 0.1f; // �U��΂鎞�̌����ʁA���l���������قǂ�����������


    private void Start()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
    }
    private void FixedUpdate()
    {
        // �U��΂鑬�x���v�Z
        var velocity = direction * speed;

        // �U��΂点��
        transform.localPosition += velocity;

        // ����������
        speed *= brake;

        // �v���C���[�̌��ݒn���擾����
        var playerPos = player.transform.position;

        // �v���C���[�ƕ�΂̋������v�Z����
        var distance = Vector3.Distance(playerPos, transform.position);

        // �v���C���[�ƕ�΂̋������߂Â����ꍇ
        if (distance < followDistance)
        {
            // �v���C���[�̌��݈ʒu�֌������x�N�g�����쐬����
            var direction = playerPos - transform.position;
            direction.Normalize();

            // ��΂��v���C���[�����݂�������Ɉړ�����
            transform.position += direction * followSpeed;

            // �������Ȃ���߂Â�
            followSpeed += (followAccel * Time.deltaTime);
        }
    }
    // ��΂��o�����鎞�ɏ���������֐�
    public void Init()
    {
        Debug.Log("�r�o���ꂽ");
        // gem���ǂ̕����ɎU��΂邩�����_���Ɍ��肷��
        var angle = Random.Range(0, 360);

        // �i�s���������W�A���l�ɕϊ�
        var f = angle * Mathf.Deg2Rad;

        // �i�s�����̃x�N�g�����쐬
        direction = new Vector3(Mathf.Cos(f), Mathf.Sin(f), 0);

        // gem�̎U��΂鑬���������_���Ɍ���
        speed = Mathf.Lerp(4f, 9f, Random.value);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerController.MusicNotes_Number(number);
            Destroy(gameObject);
        }
    }
    //�󔠂��玩�g�̔ԍ������肷��
    public int Number { set { number = value; } }
}

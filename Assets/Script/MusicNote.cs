using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicNote : MonoBehaviour
{
    [SerializeField]int number;
    [SerializeField]float followDistance;
    [SerializeField]float followSpeed;
    [SerializeField]float followAccel;
    GameObject player;
    PlayerController playerController;
    private void Start()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
    }
    private void FixedUpdate()
    {
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerController.MusicNotes_Number(number);
            Destroy(gameObject);
        }
    }
}

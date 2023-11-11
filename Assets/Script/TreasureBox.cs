using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureBox : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    PlayerController playerController;
    [SerializeField] float reactionDistance;
    [SerializeField] GameObject miniGame;
    [SerializeField] int maxDialCount;
    [SerializeField]DialManager dialManager;

    void Start()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // �v���C���[�̌��ݒn���擾����
        var playerPos = player.transform.position;

        // �v���C���[�ƕ�΂̋������v�Z����
        var distance = Vector3.Distance(playerPos, transform.position);
        // �v���C���[�ƕ�΂̋������߂Â����ꍇ
        if (distance < reactionDistance)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                playerController.IsMove = false;
                miniGame.SetActive(true);
                dialManager.Dials_Set(maxDialCount);
            }
        }
    }
}
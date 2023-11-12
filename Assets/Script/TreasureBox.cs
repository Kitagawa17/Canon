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
    [SerializeField] int[] musicNotes;//�����̔ԍ�
    [SerializeField] GameObject musicHandsPrefab;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;
    [SerializeField] GameObject aftertreasureBox;
    [SerializeField] GameObject white;

    void Start()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
    }
    void Update()
    {
        // �v���C���[�̌��ݒn���擾����
        var playerPos = player.transform.position;

        // �v���C���[�ƕ�΂̋������v�Z����
        var distance = Vector3.Distance(playerPos, transform.position);
        // �v���C���[�ƕ�΂̋������߂Â����ꍇ
        if (distance < reactionDistance)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                white.SetActive(false);
                audioSource.PlayOneShot(audioClip);
                playerController.IsMove = false;
                miniGame.SetActive(true);
                dialManager.Dials_Set(maxDialCount);
                dialManager.SetCurrentTreasureBox = gameObject;
            }
        }
    }
    //�󔠊J�����特���΂�܂�
    public void Scatter_MusicNotes()
    {
        for (var i = 0; i < musicNotes.Length; i++)
        {
            var notes = Instantiate(musicHandsPrefab, transform.position, Quaternion.identity);
            notes.GetComponent<MusicNote>().Number = musicNotes[i];
            notes.GetComponent<MusicNote>().Init();
        }
    }
    //�_�C�A���̃Q�[�����I�������󔠏���
    public void DestroyTreasureBox()
    {
        white.SetActive(true);
        Instantiate(aftertreasureBox, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialManager : MonoBehaviour
{
    [SerializeField] GameObject[] dials;//���ׂẴ_�C�����̃I�u�W�F
    [SerializeField] GameObject miniGame;//�_�C�����Q�[�����
    [SerializeField] DialController[] dialController;
    int[] dialsRotation=new int[5];//���ׂẴ_�C�����̊p�x
    [SerializeField]PlayerController playerController;
    GameObject currentTreasureBox;
    bool isMove;
    int currentDialIndex=0;
    int maxDialCount;
    int[] notes;
    void Update()
    {
        if (isMove)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (currentDialIndex < maxDialCount - 1)
                    currentDialIndex++;

            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (currentDialIndex > 0)
                    currentDialIndex--;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                dialController[currentDialIndex].RightTurn();

                dialsRotation[currentDialIndex] = dialController[currentDialIndex].GetDialRotation();
               Check();
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                dialController[currentDialIndex].LeftTurn();
                dialsRotation[currentDialIndex] = dialController[currentDialIndex].GetDialRotation();
                Check();
            }
        }
    }
    public void Dials_Set(int count)//�_�C�A���̍ő吔�ݒ�.���A�����ݒ�
    {
        maxDialCount = count;
        SetImage();
        currentDialIndex = 0;
        isMove= true;
    }
    void SetImage()//���������_�C�A���\��
    {
        for(var i=0;i<maxDialCount;i++)
        {
            dials[i].SetActive(true);
            dialController[i].SetRandomRotation();

            dialsRotation[i] = dialController[i].GetDialRotation();

        }
        for (var i=maxDialCount;i<dials.Length;i++)
        {
            dials[i].SetActive(false);
        }
    }
    void Check()//�_�C�A����������Ă邩�`�F�b�N
    {
        bool check = true;
        int num = 0;
        for (var i = 0; i < maxDialCount; i++)
        {
            if (i == 0)
            {
                num = dialsRotation[i];
            }
            else
            {
                if (num != dialsRotation[i])
                {
                    check = false;
                }

            }

        }
        if (check)//�I�����̏���
        {
            miniGame.SetActive(false);
            StartCoroutine(wait());

            if (currentTreasureBox != null)
            {
                //�������o������
                currentTreasureBox.GetComponent<TreasureBox>().Scatter_MusicNotes();
                //�󔠏���
                currentTreasureBox.GetComponent<TreasureBox>().DestroyTreasureBox();
            }

        }

    }
    IEnumerator wait()//�v���C���[������
    {
        yield return new WaitForSeconds(0.5f);
        playerController.IsMove = true;

    }
    public GameObject SetCurrentTreasureBox
    {
        set { currentTreasureBox = value; }
    }
   
}

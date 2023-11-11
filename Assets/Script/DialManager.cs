using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialManager : MonoBehaviour
{
    [SerializeField] GameObject[] dials;
    [SerializeField] GameObject miniGame;
    [SerializeField] DialController[] dialController;
    int[] dialsRotation=new int[5];
    [SerializeField]PlayerController playerController;
    GameObject currentTreasureBox;
    bool isMove;
    int currentDialIndex=0;
    int maxDialCount;
    void Update()
    {
        if (isMove)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (currentDialIndex < maxDialCount - 1)
                    currentDialIndex++;
                Debug.Log(currentDialIndex);

            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (currentDialIndex > 0)
                    currentDialIndex--;
                Debug.Log(currentDialIndex);
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
        Debug.Log(dialsRotation[0]);
        Debug.Log(dialsRotation[1]);
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

            //�󔠂��特�����炤
            int[] notes = currentTreasureBox.GetComponent<TreasureBox>().MusicNotes;
            //��������������v���C���[�ɓn��
            playerController.TreaureBox_MusicNotes(notes);
            //�󔠏���
            if (currentTreasureBox!=null)
                currentTreasureBox.GetComponent<TreasureBox>().DestroyTreasureBox();
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

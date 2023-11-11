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
    public void Dials_Set(int count)//ダイアルの最大数設定.他、初期設定
    {
        maxDialCount = count;
        SetImage();
        currentDialIndex = 0;
        isMove= true;
    }
    void SetImage()//個数分だけダイアル表示
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
    void Check()//ダイアルがそろってるかチェック
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
        if (check)//終了時の処理
        {
            miniGame.SetActive(false);
            StartCoroutine(wait());

            //宝箱から音符もらう
            int[] notes = currentTreasureBox.GetComponent<TreasureBox>().MusicNotes;
            //もらった音符をプレイヤーに渡す
            playerController.TreaureBox_MusicNotes(notes);
            //宝箱消す
            if (currentTreasureBox!=null)
                currentTreasureBox.GetComponent<TreasureBox>().DestroyTreasureBox();
        }
        
    }
    IEnumerator wait()//プレイヤー動かす
    {
        yield return new WaitForSeconds(0.5f);
        playerController.IsMove = true;

    }
    public GameObject SetCurrentTreasureBox
    {
        set { currentTreasureBox = value; }
    }
}

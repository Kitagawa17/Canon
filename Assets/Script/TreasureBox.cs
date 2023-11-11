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
    [SerializeField] int[] musicNotes;//音符の番号
    [SerializeField] GameObject musicHandsPrefab;

    void Start()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
    }
    void Update()
    {
        // プレイヤーの現在地を取得する
        var playerPos = player.transform.position;

        // プレイヤーと宝石の距離を計算する
        var distance = Vector3.Distance(playerPos, transform.position);
        // プレイヤーと宝石の距離が近づいた場合
        if (distance < reactionDistance)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                playerController.IsMove = false;
                miniGame.SetActive(true);
                dialManager.Dials_Set(maxDialCount);
                dialManager.SetCurrentTreasureBox = gameObject;
            }
        }
    }
    //宝箱開いたら音符ばらまく
    public void Scatter_MusicNotes()
    {
        for (var i = 0; i < musicNotes.Length; i++)
        {
            var notes = Instantiate(musicHandsPrefab, transform.position, Quaternion.identity);
            notes.GetComponent<MusicNote>().Number = musicNotes[i];
            notes.GetComponent<MusicNote>().Init();
        }
    }
    //ダイアルのゲームが終わったら宝箱消す
    public void DestroyTreasureBox()
    {
        Destroy(gameObject);
    }
}

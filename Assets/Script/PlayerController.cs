using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float player_speed; //プレイヤーの移動速度
    bool[] musicNotesNumber = new bool[32];//取得してる音符情報ここに保持
    [SerializeField]GameObject[] musicNotesGameObjects = new GameObject[32];//取得してる音符情報ここに保持
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;

    bool isMove = true;//移動するかいなか
    void FixedUpdate()
    {
        if (isMove)
        {
            //移動方向取得
            var h = Input.GetAxis("Horizontal");
            var v = Input.GetAxis("Vertical");
            //常に一定速度で移動させる
            var velocity = (new Vector3(h, v).normalized) * player_speed * Time.deltaTime;
            transform.position += velocity;

        }
    }
    //音符と接触したら呼び出されて番号格納,音符表示
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicNote : MonoBehaviour
{
    [SerializeField]int number;//自身の番号
    [SerializeField]float followDistance;
    [SerializeField]float followSpeed;
    [SerializeField]float followAccel;
    GameObject player;
    PlayerController playerController;

    Vector3 direction; // 散らばる時の進行方向
    float speed; // 散らばる時の速さ
    [SerializeField] float brake = 0.1f; // 散らばる時の減速量、数値が小さいほどすぐ減速する


    private void Start()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
    }
    private void FixedUpdate()
    {
        // 散らばる速度を計算
        var velocity = direction * speed;

        // 散らばらせる
        transform.localPosition += velocity;

        // 減速させる
        speed *= brake;

        // プレイヤーの現在地を取得する
        var playerPos = player.transform.position;

        // プレイヤーと宝石の距離を計算する
        var distance = Vector3.Distance(playerPos, transform.position);

        // プレイヤーと宝石の距離が近づいた場合
        if (distance < followDistance)
        {
            // プレイヤーの現在位置へ向かうベクトルを作成する
            var direction = playerPos - transform.position;
            direction.Normalize();

            // 宝石をプレイヤーが存在する方向に移動する
            transform.position += direction * followSpeed;

            // 加速しながら近づく
            followSpeed += (followAccel * Time.deltaTime);
        }
    }
    // 宝石が出現する時に初期化する関数
    public void Init()
    {
        Debug.Log("排出された");
        // gemがどの方向に散らばるかランダムに決定する
        var angle = Random.Range(0, 360);

        // 進行方向をラジアン値に変換
        var f = angle * Mathf.Deg2Rad;

        // 進行方向のベクトルを作成
        direction = new Vector3(Mathf.Cos(f), Mathf.Sin(f), 0);

        // gemの散らばる速さをランダムに決定
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
    //宝箱から自身の番号を決定する
    public int Number { set { number = value; } }
}

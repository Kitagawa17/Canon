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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerController.MusicNotes_Number(number);
            Destroy(gameObject);
        }
    }
}

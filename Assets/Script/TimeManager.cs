using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] float LimitTimer;
    [SerializeField] GameObject finishImage;
    void Update()
    {
        LimitTimer-=Time.deltaTime;
        if(LimitTimer <= 0)
        {
            //時間が終了したときの処理
            finishImage.SetActive(true);
        }
    }
}

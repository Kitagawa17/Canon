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
            //���Ԃ��I�������Ƃ��̏���
            finishImage.SetActive(true);
        }
    }
}

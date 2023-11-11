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
            //ŽžŠÔ‚ªI—¹‚µ‚½‚Æ‚«‚Ìˆ—
            finishImage.SetActive(true);
        }
    }
}

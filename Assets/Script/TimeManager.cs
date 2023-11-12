using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    [SerializeField] float limitTimer;
    [SerializeField] GameObject finishImage;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] PlayerController playerController;

    void Update()
    {
        limitTimer-=Time.deltaTime;
        int timer = (int)limitTimer;
        timerText.text = timer.ToString();
        if(limitTimer <= 0)
        {
            //ŽžŠÔ‚ªI—¹‚µ‚½‚Æ‚«‚Ìˆ—
            finishImage.SetActive(true);
            timerText.enabled = false;
            bool[] nums = playerController.MusicNotesNumber;
            int count = 0;
            foreach(var p in nums)
            {
                if(p)
                    count++;
            }
            float score = count / 32.0f * 100.0f;
            scoreText.enabled = true;
            scoreText.text = $"{score} %";

        }

    }
}

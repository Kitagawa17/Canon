using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MusicHand : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int musicNotes_Number;
    [SerializeField] Sound sound;
    [SerializeField] float speed;

    void FixedUpdate()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector3(rectTransform.anchoredPosition.x - speed, rectTransform.anchoredPosition.y);
        if (rectTransform.anchoredPosition.x < -2512.7f)
            rectTransform.anchoredPosition = new Vector3(437.6f, rectTransform.anchoredPosition.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SequenceBar"))
        {
            sound.SourceNumber(musicNotes_Number);
        }
    }
}

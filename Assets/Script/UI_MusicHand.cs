using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MusicHand : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int musicNotes_Number;
    [SerializeField] Sound sound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SequenceBar"))
        {
            Debug.Log("aaa");
            sound.SourceNumber(musicNotes_Number);
        }
    }
}

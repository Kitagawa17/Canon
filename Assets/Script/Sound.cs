using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] AudioClip[] musics = new AudioClip[32];
    [SerializeField] AudioSource audioSource;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void  SourceNumber(int num)
    {
        //Ç±Ç±Ç≈ÇªÇÃî‘çÜÇÃâπåπñ¬ÇÁÇ∑
        audioSource.PlayOneShot(musics[num]);
        Debug.Log(num);
    }
}

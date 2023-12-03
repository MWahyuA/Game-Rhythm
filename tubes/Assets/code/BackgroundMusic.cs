using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BackgroundMusic : MonoBehaviour
{
    public AudioSource bgm1;
    public AudioSource bgm2;

    void Start()
    {
        // Memastikan lagu kedua dimatikan saat memulai proyek
        bgm2.Stop();
    }

    void Update()
    {
        // Jika lagu pertama telah selesai dimainkan, putar lagu kedua
        if (!bgm1.isPlaying && !bgm2.isPlaying)
        {
            bgm2.Play();
        }
        // Jika lagu kedua telah selesai dimainkan, putar lagu pertama
        else if (!bgm2.isPlaying && !bgm1.isPlaying)
        {
            bgm1.Play();
        }
    }
}

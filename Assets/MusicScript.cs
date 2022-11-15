using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    void Update()
    {
        if (STATIC.IsMusicOn)
        {
            if (!GetComponent<AudioSource>().isPlaying)
            {
                STATIC.CurrentMusic++;
                if (STATIC.CurrentMusic == 4) STATIC.CurrentMusic = 1;
                GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Music/" + STATIC.CurrentMusic);
                GetComponent<AudioSource>().Play();
            }
        }
        else
        {
            GetComponent<AudioSource>().clip = null;
        }
    }
}

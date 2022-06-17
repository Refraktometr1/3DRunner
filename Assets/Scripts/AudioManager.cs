using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class AudioManager : MonoSingleton<AudioManager>
{
    public AudioSource AudioSource;
    public AudioSource MusicSource;
    private bool isMusicOn;
    public bool isSoundOff;

    public void PlaySound(AudioClip audioClip)
    {
        if (isSoundOff)
            return;
        
        AudioSource.PlayOneShot(audioClip);
    }

    public bool MusicOff()
    {
        isMusicOn = !isMusicOn;
        MusicSource.mute = isMusicOn;
        return isMusicOn;
    }
}

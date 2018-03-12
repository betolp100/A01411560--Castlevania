using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioClip[] audioClips;
    public AudioSource sound;
    public static SoundManager instance = null;

    public void PlaySong(int i)    //Play sounds
    {
        if (sound != null)
        {
              sound.Stop();
        }
        sound.clip = audioClips[i];
        sound.Play();
    }
}

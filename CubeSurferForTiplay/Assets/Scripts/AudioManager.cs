using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager _instance;

    [SerializeField] AudioClip cubeCollect, diamondCollect, cubeLose, win, death;
    [SerializeField] AudioSource audioSource;

    private void Awake()
    {
        if (_instance == null) { _instance = this; }
    }

    public void PlayMusic(int number) 
    {
        if(number == 0) { audioSource.PlayOneShot(cubeCollect); }
        if(number == 1) { audioSource.PlayOneShot(diamondCollect); }
        if(number == 2) { audioSource.PlayOneShot(cubeLose); }
        if(number == 3) { audioSource.PlayOneShot(win); }
        if(number == 4) { audioSource.PlayOneShot(death); }
    }



}

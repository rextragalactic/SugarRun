using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioSource BackgroundSound;
    public static SoundManager instance;

    private void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);



        DontDestroyOnLoad(gameObject); //Dont Destoy the attached Script

        
    }

    private void Update()
    {
        
    }

    public void ChangeSound(AudioClip music)
    {
        if (BackgroundSound.clip.name == music.name)
            return;

        BackgroundSound.Stop();
        BackgroundSound.clip = music;
        BackgroundSound.Play();
    }

}

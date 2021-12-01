using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusicOnLoad : MonoBehaviour
{
    public AudioClip NewTrack;

    private SoundManager theSoundManager;

    // Start is called before the first frame update
    void Start()
    {
        theSoundManager = FindObjectOfType<SoundManager>();

        if(NewTrack != null)
        theSoundManager.ChangeSound(NewTrack);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusicTrigger : MonoBehaviour
{

    public AudioClip NewTrack;

    private SoundManager theSoundManager;

    // Start is called before the first frame update
    void Start()
    {
        theSoundManager = FindObjectOfType<SoundManager>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(NewTrack != null)
            theSoundManager.ChangeSound(NewTrack);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This Script will check if we have a Sound Manager in the Level
public class SoundManagerCheck : MonoBehaviour
{
    public GameObject soundMan; // = Sound Manager 
    // Start is called before the first frame update
    void Start()
    {
        if (FindObjectOfType<SoundManager>())
        return;
        else
            Instantiate(soundMan, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

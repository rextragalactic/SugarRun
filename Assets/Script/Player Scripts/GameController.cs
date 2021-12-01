using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool GameStarted;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && !GameStarted)
        {
            GameStarted = true;
        }
    }
}

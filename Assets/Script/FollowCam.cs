using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{

    // What is my cam following?  
    public Transform target;

    // How long is the distance between my target and the cam? 
    private Vector3 offset;



    private void Awake()
    {
        offset = transform.position - target.position; // The position of the targer/player at this moment  - Target position (Zielposition)
    }

    // Cam movement 
    private void LateUpdate()
    {
        transform.position = target.position + offset; // Camposition at this moment = target/player position + offset (distance)
    }
}



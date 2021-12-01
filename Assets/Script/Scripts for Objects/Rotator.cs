using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
    public Vector3 angle;
    void Update() {
        transform.Rotate(angle * Time.deltaTime);
    }
}

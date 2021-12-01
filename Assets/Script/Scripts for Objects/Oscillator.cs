using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour {

    [SerializeField] Vector3 moveVector;
    [SerializeField] float period;

    [Range(0, 1)][SerializeField] float movmentFactor;
    
    Vector3 starterPos;
    [SerializeField] bool isEnabled;

	// Use this for initialization
	void Start () {
        starterPos = transform.localPosition;
	}

    public void Enable(Vector3 dir)
    {
        moveVector = dir;
        isEnabled = true;
        gameObject.SetActive(true);
    }

    void Update () {
        if (isEnabled)
        {
            if(period <= Mathf.Epsilon) { return; }
            float cycle = Time.time / period;
            const float tau = Mathf.PI * 2;
            float rawSinWave = Mathf.Sin(cycle*tau);

            movmentFactor = rawSinWave / 2f+.5f;
            Vector3 offst = moveVector * movmentFactor;
            transform.localPosition = starterPos + offst;
        }
	}
}

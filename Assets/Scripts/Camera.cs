using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    public float panSpeed = 0.5f;
    public bool panCam = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(panCam)
            transform.Translate(Vector3.right * Time.deltaTime * panSpeed);
	}
}

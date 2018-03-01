using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pitfall : MonoBehaviour {

    public bool FallFlag = false;
    public float FallSpeed = 2.0f;

    // Use this for initialization
    void Start () {
	}

    void processGravity()
    {
        if (FallFlag)
        {
            transform.Translate(Vector3.down * FallSpeed * Time.deltaTime);
        }
    }
    
    public void setFallTrue()
    {
        FallFlag = true;
    }

    // Update is called once per frame
    void Update () {
        processGravity();
		
	}
}

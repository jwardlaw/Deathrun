using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    public bool crossed = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            crossed = true;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

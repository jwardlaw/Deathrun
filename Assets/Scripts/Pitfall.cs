using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pitfall : MonoBehaviour {

    public bool FallFlag = false;
    public bool ReverseFlag = false;
    public float FallSpeed = 2.0f;
    public SpriteRenderer label;
    private float cooldown = 2.8f;
    private float refreshTimeStamp;
    private Vector3 startPos;

    // Use this for initialization
    void Start () {
        startPos = transform.position;
	}

    void processGravity()
    {
        if (FallFlag)
        { 
            label.enabled = false;
            transform.Translate(Vector3.down * FallSpeed * Time.deltaTime);
            if(Vector3.Distance(transform.position, startPos) > 10f)
            {
                FallFlag = false;
                ReverseFlag = true;
            }
        }
        if(ReverseFlag)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, FallSpeed * Time.deltaTime);
            if(Vector3.Distance(transform.position, startPos) < 0.01f)
            {
                ReverseFlag = false;
            }
        }
    }
    
    public void setFallTrue()
    {
        if(refreshTimeStamp <= Time.time)
        {
            refreshTimeStamp = Time.time + cooldown;
            FallFlag = true;
        }
    }

    // Update is called once per frame
    void Update () {
        if(refreshTimeStamp <= Time.time)
        {
            label.enabled = true;
        }
        processGravity();
		
	}
}

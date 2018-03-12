using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuSpike : MonoBehaviour {

    public bool RaiseFlag = false;
    public bool ReverseFlag = false;
    public float RaiseSpeed = 1.0f;
    private float cooldown = 2.8f;
    private float refreshTimeStamp;
    private Vector3 startPos;
    private AudioSource aus;

    // Use this for initialization
    void Start () {
        startPos = transform.position;
        aus = GetComponent<AudioSource>();
    }

    void triggerTrap()
    {
        transform.Translate(Vector3.up * 0.5f); //Vector3.up * RaiseSpeed * Time.deltaTime);
        RaiseFlag = false;
        ReverseFlag = true;
    }

    public void setRaiseTrue()
    {
        if (refreshTimeStamp <= Time.time)
        {
            refreshTimeStamp = Time.time + cooldown;
            RaiseFlag = true;
            aus.Play();
        }
    }

    void resetPosition()
    {
        if (ReverseFlag)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, RaiseSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, startPos) < 0.01f)
            {
                ReverseFlag = false;
            }
        }
    }

    // Update is called once per frame
    void Update () {

        if (refreshTimeStamp <= Time.time)
        {
            setRaiseTrue();
        }

        if (RaiseFlag == true)
        {
            triggerTrap();
        }

        resetPosition();
    }
}

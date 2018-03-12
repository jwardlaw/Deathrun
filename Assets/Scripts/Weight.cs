using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weight : MonoBehaviour {

    public bool FallFlag = false;
    public float FallSpeed = 3.0f;
    public SpriteRenderer label;
    private float cooldown = 2.8f;
    private float refreshTimeStamp;
    public Collider myCol;
    public Rigidbody rb;
    private AudioSource aus;

    private void Awake()
    {
        aus = GetComponent<AudioSource>();
    }

    void processGravity()
    {
        if (FallFlag)
        {

            //label.enabled = false;
            //transform.Translate(Vector3.down * FallSpeed * Time.deltaTime);
            rb.isKinematic = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player" && rb.velocity != new Vector3(0,0,0))
        {
            other.gameObject.SendMessage("setDead");
            other.gameObject.SetActive(false);
            //            Destroy(other.gameObject);
        }


        if (other.transform.tag == "Floor")
            myCol.isTrigger = false;
    }


    public void setFallTrue()
    {
        if (refreshTimeStamp <= Time.time)
        {
            refreshTimeStamp = Time.time + cooldown;
            FallFlag = true;
            label.enabled = false;
            aus.Play();
        }
    }

    // Update is called once per frame
    void Update () {

        processGravity();
    }
}

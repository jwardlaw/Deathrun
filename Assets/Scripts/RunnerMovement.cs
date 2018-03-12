using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class RunnerMovement : MonoBehaviour {
    private int playerId = 0;

    private Player player;
    private CharacterController cc;
    private SpriteRenderer sr;
    private AudioSource aus;

    private float moveSpeed = 3f;
    private float fallSpeed = -4f;
    private Vector3 moveDir;
    private float jumpSpeed = 1.5f;
    private float gravity = 3.5f;
    private float jumpRate = 0.5f;
    private float lastJump = 0.0f;
    private bool isJumping = false;
    private bool isWalking = false;
    public bool isDead = false;

    // sounds
    public AudioClip walk;
    public AudioClip jump;

    void getInput()
    {
        moveDir.x = player.GetAxis("WalkHorizontal");
        if (moveDir.x != 0 && cc.isGrounded)
            isWalking = true;
        if (moveDir.x == 0 && cc.isGrounded)
            isWalking = false;

        // Jump
        if (player.GetButtonDown("Jump") && cc.isGrounded)
        {
            if (Time.time > jumpRate + lastJump)
            {
                moveDir.y = jumpSpeed;
                isJumping = true;
                isWalking = false;
            }
            lastJump = Time.time;
        }
        else
        {
            isJumping = false;
        }
    }

    void processInput()
    {
        if (moveDir.x != 0.0f || moveDir.y != 0.0f)
        {
            // Debug.Log("move");
            cc.Move(moveDir * moveSpeed * Time.deltaTime);
        }
        if(moveDir.x < 0)
        {
            sr.flipX = true;
        }
        else if(moveDir.x > 0)
        {
            sr.flipX = false;
        }
    }

    void processGravity()
    {
        if(/*moveDir.y >= fallSpeed && */!cc.isGrounded)
        {
            moveDir.y -= gravity * Time.deltaTime;
            cc.Move(moveDir * Time.deltaTime);
        }
        else if(cc.isGrounded)
        {
            moveDir.y = 0;
        }
    }

    void fallDeath()
    {
        if (transform.position.y < -3.3)
        {
            //Destroy(gameObject);
            isDead = true;
            gameObject.SetActive(false);
            Debug.Log("fall");
        }   
    }

    void setDead()
    {
        isDead = true;
    }

	// Use this for initialization
	void Awake() {
        player = ReInput.players.GetPlayer(playerId);

        // Get the character controller
        cc = GetComponent<CharacterController>();

        sr = GetComponent<SpriteRenderer>();

        aus = GetComponent<AudioSource>();
    }

    void processSounds()
    {
        if(isWalking)
        {
            if(aus.clip != walk)
            {
                aus.Stop();
                aus.clip = walk;
            }

            if(! aus.isPlaying)
            {
                aus.Play();
            }
        }
        else if(isJumping)
        {
            if(aus.clip != jump)
            {
                aus.Stop();
                aus.clip = jump;
            }

            if(!aus.isPlaying)
            {
                aus.Play();
            }
        }
        else
        {
            aus.Stop();
        }

        /*
        // walk
        if (cc.isGrounded && player.GetAxis("WalkHorizontal") != 0)
        {
            GetComponent<AudioSource>().UnPause();
        }
        if (player.GetButtonDown("Jump") && cc.isGrounded)
        {
            GetComponent<AudioSource>().clip = jump;
            GetComponent<AudioSource>().UnPause();
        }
        else
        {
            GetComponent<AudioSource>().Pause();
        }

        /*
        // Jump
        if (player.GetButtonDown("Jump") && cc.isGrounded)
        {
            GetComponent<AudioSource>().clip = jump;
            GetComponent<AudioSource>().UnPause();
        }
        if (cc.isGrounded)
        {
            GetComponent<AudioSource>().clip = walk;
        }
        */
    }

	// Update is called once per frame
	void Update () {
        getInput();
        processInput();
        processGravity();
        processSounds();
        fallDeath();
    }
}

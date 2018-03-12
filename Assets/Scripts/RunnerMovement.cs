using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class RunnerMovement : MonoBehaviour {
    private int playerId = 0;

    private Player player;
    private CharacterController cc;
    private SpriteRenderer sr;

    private float moveSpeed = 3f;
    private float fallSpeed = -4f;
    private Vector3 moveDir;
    private float jumpSpeed = 1.5f;
    private float gravity = 3.5f;
    private float jumpRate = 0.5f;
    private float lastJump = 0.0f;

    void getInput()
    {
        moveDir.x = player.GetAxis("WalkHorizontal");
        // Jump
        if (player.GetButtonDown("Jump") && cc.isGrounded)
        {
            if (Time.time > jumpRate + lastJump)
            {
                moveDir.y = jumpSpeed;
            }
            lastJump = Time.time;
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
            Destroy(gameObject);
            Debug.Log("fall");
        }
            
    }

	// Use this for initialization
	void Awake() {
        player = ReInput.players.GetPlayer(playerId);

        // Get the character controller
        cc = GetComponent<CharacterController>();

        sr = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        getInput();
        processInput();
        processGravity();
        fallDeath();
    }
}

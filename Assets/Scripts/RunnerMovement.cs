using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class RunnerMovement : MonoBehaviour {
    private int playerId = 0;

    private Player player;
    private CharacterController cc;

    private float moveSpeed = 3f;
    private Vector3 moveDir;
    private float jumpSpeed = 0.50f;
    private float gravity = 1.0f;
    private float jumpRate = 0.5f;
    private float lastJump = 0.0f;

    void getInput()
    {
        moveDir.x = player.GetAxis("WalkHorizontal");
        // Jump
        if (Input.GetButtonDown("Jump") && cc.isGrounded)
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
    }

    void processGravity()
    {
        moveDir.y -= gravity * Time.deltaTime;
        cc.Move(moveDir * Time.deltaTime);
    }

	// Use this for initialization
	void Awake() {
        player = ReInput.players.GetPlayer(playerId);

        // Get the character controller
        cc = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {
        getInput();
        processInput();
        processGravity();
    }
}

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

    void getInput()
    {
        moveDir.x = player.GetAxis("WalkHorizontal");
    }

    void processInput()
    {
        if (moveDir.x != 0.0f || moveDir.y != 0.0f)
        {
            Debug.Log("move");
            cc.Move(moveDir * moveSpeed * Time.deltaTime);
        }
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
		
	}
}

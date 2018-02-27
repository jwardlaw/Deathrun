using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class GameManager : MonoBehaviour {

    public Player p1;
    public Player p2;
    public Player p3;
    public Player p4;
    

	// Use this for initialization
	void Start () {

        p1 = ReInput.players.GetPlayer(0);

    }

    void swapControls()
    {
        foreach (Joystick joystick in p1.controllers.Joysticks)
        {
            p1.controllers.maps.LoadMap(ControllerType.Joystick, joystick.id, "Default", "Runner", true);
        }
    }

	// Update is called once per frame
	void Update () {

        if(Input.GetButtonDown("Jump"))
        {
            Debug.Log("Swap");
            swapControls();
        }
		
	}
}

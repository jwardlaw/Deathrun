using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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
        p2 = ReInput.players.GetPlayer(1);
    }

    void swapControls()
    {
        foreach (Joystick joystick in p1.controllers.Joysticks)
        {
            p1.controllers.maps.LoadMap(ControllerType.Joystick, joystick.id, "Default", "Runner", true);
        }
    }

    private void resetScene()
    {
        if(Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene("JoshTest");
        }
    }

    // Update is called once per frame
    void Update () {

        resetScene();
        if(Input.GetButtonDown("Jump"))
        {
            Debug.Log("Swap");
            swapControls();
        }
        
		
	}
}

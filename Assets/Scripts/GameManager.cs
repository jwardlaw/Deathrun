using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Rewired;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Player p1;
    public Player p2;
    public Player p3;
    public Player p4;
    private Camera cam;
    public GameObject thePlayer;
    public GameObject theTrapper;
    public GameObject goalLine;
    public Text trapWin;
    public Text runWin;


    private bool trapperWin = false;
    private bool runnerWin = false;


    

	// Use this for initialization
	void Start () {

        p1 = ReInput.players.GetPlayer(0);
        p2 = ReInput.players.GetPlayer(1);
        cam = (Camera) FindObjectOfType(typeof(Camera));
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

    private void gameOver()
    {
        
        if (thePlayer.GetComponent<RunnerMovement>().isDead)
        {
            trapperWin = true;
            trapWin.gameObject.SetActive(true);
        }
            

        if (goalLine.GetComponent<Goal>().crossed)
        {
            runnerWin = true;
            runWin.gameObject.SetActive(true);
        }

            
        if(trapperWin || runnerWin)
        {
            cam.panCam = false;
            thePlayer.GetComponent<RunnerMovement>().canInput = false;
            thePlayer.GetComponent<RunnerMovement>().stopMove();
            theTrapper.GetComponent<Trapper>().canInput = false;
        }
    }

    // Update is called once per frame
    void Update () {

        resetScene();
        gameOver();
        /*
        if(Input.GetButtonDown("Jump"))
        {
            Debug.Log("Swap");
            swapControls();
        }
        */	
	}
}

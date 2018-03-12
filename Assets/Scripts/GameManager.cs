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
    public Transform canvas;


    private bool trapperWin = false;
    private bool runnerWin = false;

    private void Awake()
    {
        p1 = ReInput.players.GetPlayer(0);
        p2 = ReInput.players.GetPlayer(1);
        cam = (Camera)FindObjectOfType(typeof(Camera));
    }

    private void Start()
    {
        canvas.gameObject.SetActive(false);
        cam.panCam = true;
        Time.timeScale = 1;
        thePlayer.GetComponent<RunnerMovement>().canInput = true;
        theTrapper.GetComponent<Trapper>().canInput = true;
    }

    void swapControls()
    {
        foreach (Joystick joystick in p1.controllers.Joysticks)
        {
            p1.controllers.maps.LoadMap(ControllerType.Joystick, joystick.id, "Default", "Runner", true);
        }
    }

    public void resetScene()
    {
        SceneManager.LoadScene("JoshTest");
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

    public void exitGame()
    {
        Application.Quit();
    }

    public void resume()
    {
        canvas.gameObject.SetActive(false);
        cam.panCam = true;
        Time.timeScale = 1;
        thePlayer.GetComponent<RunnerMovement>().canInput = true;
        theTrapper.GetComponent<Trapper>().canInput = true;
    }

    public void loadMenu()
    {
       

        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    
    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canvas.gameObject.activeInHierarchy == false)
            {
                canvas.gameObject.SetActive(true);
                cam.panCam = false;
                thePlayer.GetComponent<RunnerMovement>().canInput = false;
                // thePlayer.GetComponent<RunnerMovement>().stopMove();
                theTrapper.GetComponent<Trapper>().canInput = false;
                Time.timeScale = 0;
            }

            else
            {
                canvas.gameObject.SetActive(false);
                cam.panCam = true;
                Time.timeScale = 1;
                thePlayer.GetComponent<RunnerMovement>().canInput = true;
                theTrapper.GetComponent<Trapper>().canInput = true;
            }
        }
      
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

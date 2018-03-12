using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class Trapper : MonoBehaviour {
    private int playerId = 1;
    private Player player;
    public GameObject trap1;
    public GameObject trap2;
    public GameObject trap3;


    private void Awake()
    {
        player = ReInput.players.GetPlayer(playerId);
    }


    void getInput()
    {
        if (player.GetButtonDown("TrapA") /* && player.GetAxisRaw("TrapA") != 0 */)
        {
            Debug.Log("TrapA");
            trap1.GetComponent<Pitfall>().setFallTrue();
        }

        if (player.GetButtonDown("TrapB") /* && player.GetAxisRaw("TrapB") != 0 */)
        {
            Debug.Log("TrapB");
            trap2.GetComponent<Spike>().setRaiseTrue();
        }

        if (player.GetButtonDown("TrapX") /* && player.GetAxisRaw("TrapB") != 0 */)
        {
            Debug.Log("TrapX");
            trap3.GetComponent<Weight>().setFallTrue();
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        getInput();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class Trapper : MonoBehaviour {
    private int playerId = 1;
    private Player player;
    public List<Trap> traps;

    public GameObject trap1;
    public GameObject trap2;
    public GameObject trap3;
    public bool canInput = true;


    private void Awake()
    {
        traps = new List<Trap>();
        player = ReInput.players.GetPlayer(playerId);
    }


    void getInput()
    {
        if (player.GetButtonDown("TrapA") /* && player.GetAxisRaw("TrapA") != 0 */)
        {
            Debug.Log("TrapA");
            if(traps.Count >= 1)
                traps[0].Trigger();
        }

        if (player.GetButtonDown("TrapX") /* && player.GetAxisRaw("TrapB") != 0 */)
        {
            Debug.Log("TrapX");
            if(traps.Count >= 2)
                traps[1].Trigger();
        }

        if (player.GetButtonDown("TrapY") /* && player.GetAxisRaw("TrapB") != 0 */)
        {
            Debug.Log("TrapY");
            if(traps.Count >= 3)
                traps[2].Trigger();
        }
        if (player.GetButtonDown("TrapB") /* && player.GetAxisRaw("TrapB") != 0 */)
        {
            Debug.Log("TrapB");
            if(traps.Count >= 4)
                traps[3].Trigger();
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(canInput)
            getInput();
	}
}

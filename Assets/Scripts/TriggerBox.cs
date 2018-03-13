using UnityEngine;
using System.Collections;

public class TriggerBox : MonoBehaviour
{
    Trapper trapper;
    Trap trap;
    BoxCollider box;

    Sprite[] sprites;
    // Use this for initialization
    void Start()
    {
        box = GetComponent<BoxCollider>();
        trapper = GameObject.Find("Trapper").GetComponent<Trapper>();
        trap = transform.parent.GetComponent<Trap>();

        sprites = new Sprite[4];

        sprites[0] = Resources.Load("button_sprites_0", typeof(Sprite)) as Sprite;
        sprites[1] = Resources.Load("button_sprites_1", typeof(Sprite)) as Sprite;
        sprites[2] = Resources.Load("button_sprites_2", typeof(Sprite)) as Sprite;
        sprites[3] = Resources.Load("button_sprites_3", typeof(Sprite)) as Sprite;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Enter");
            trapper.traps.Add(trap);
            trap.label.sprite = sprites[trapper.traps.IndexOf(trap)];
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            trap.label.sprite = sprites[trapper.traps.IndexOf(trap)];
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Exit");
            trapper.traps.Remove(trap);
            trap.label.sprite = null;
        }
    }
}

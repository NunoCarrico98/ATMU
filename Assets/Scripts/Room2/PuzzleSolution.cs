using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSolution : MonoBehaviour
{

    public bool close = false;
    public Transform limitPoint;
    private Transform player;
    private FloorCollider floorCollider;
    private OpenTrap openTrap;
    private ConfirmationLight confirmLight;

    // Use this for initialization
    void Start()
    {
        floorCollider = FindObjectOfType<FloorCollider>();
        openTrap = FindObjectOfType<OpenTrap>();
        confirmLight = FindObjectOfType<ConfirmationLight>();

        player = GameObject.Find("Player").transform;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "HeavyBox" || col.tag == "BoxCollider")
        {
            close = true;
            floorCollider.playerEnter = false;
            floorCollider.open = false;
            openTrap.open = false;

            confirmLight.spriteR.enabled = true;
            floorCollider.greenLight = true;
            floorCollider.redLight = false;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "HeavyBox" || col.tag == "BoxCollider")
        {
            // if (player.position.x < limitPoint.position.x)
            //{
            close = false;
           // floorCollider.greenLight = false;
            floorCollider.redLight = false;
            confirmLight.spriteR.enabled = false;
            // }
        }
    }
}

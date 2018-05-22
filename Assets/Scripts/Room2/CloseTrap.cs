using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseTrap : MonoBehaviour {

    private FloorCollider floorCollider;
    private OpenTrap openTrap;

    private void Start()
    {
        floorCollider = FindObjectOfType<FloorCollider>();
        openTrap = FindObjectOfType<OpenTrap>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" || col.tag == "LightBox")
        {
            floorCollider.playerEnter = false;
            floorCollider.open = false;
            floorCollider.redLight = false;
            floorCollider.greenLight = false;
            openTrap.open = false;
        }
    }
}

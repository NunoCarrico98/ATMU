using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCollider : MonoBehaviour {

    public bool open = false;
    public bool playerEnter = false;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            playerEnter = true;
        }
        if (col.tag == "LightBox")
        {
            open = true;
        }
    }
}

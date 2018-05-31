using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerPuzzle : MonoBehaviour {

    public  static bool isInside = false;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            isInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            isInside = false;
        }
    }
}

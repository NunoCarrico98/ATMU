using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentToPressurePlate : MonoBehaviour {

    private Transform parent;

    private void OnTriggerStay2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            parent = col.transform.parent;
            col.transform.SetParent(parent);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.transform.SetParent(null);
        }
    }
}

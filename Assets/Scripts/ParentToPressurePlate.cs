using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentToPressurePlate : MonoBehaviour {

    private Transform parent;

    private void OnCollisionStay2D(Collision2D col)
    {
        if(col.transform.tag == "Player")
        {
            parent = col.transform.parent;
            col.transform.SetParent(parent);
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.transform.tag == "Player")
        {
            col.transform.SetParent(null);
        }
    }
}

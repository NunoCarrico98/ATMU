using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentToPressurePlate : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            col.transform.SetParent(transform);
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

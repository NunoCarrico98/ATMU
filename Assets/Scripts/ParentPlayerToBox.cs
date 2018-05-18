using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentPlayerToBox : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "Player")
        {
            col.transform.SetParent(transform);
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

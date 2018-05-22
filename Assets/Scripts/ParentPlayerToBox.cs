using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentPlayerToBox : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Player")
        {
            col.transform.SetParent(transform.parent);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.transform.tag == "Player")
        {
            col.transform.SetParent(null);
        }
    }
}

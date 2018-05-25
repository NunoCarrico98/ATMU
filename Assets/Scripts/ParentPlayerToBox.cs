using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentPlayerToBox : MonoBehaviour
{

    //private Transform boxesParent;

    private void Start()
    {
        //boxesParent = GameObject.FindGameObjectWithTag("BoxesParent").transform;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Player" /*|| col.transform.tag == "HeavyBox" || col.transform.tag == "LightBox"*/)
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

        /*if(col.transform.tag == "HeavyBox" || col.transform.tag == "LightBox")
        {
            col.transform.SetParent(boxesParent);
        }*/
    }
}

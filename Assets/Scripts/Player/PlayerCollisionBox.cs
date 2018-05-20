using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionBox : MonoBehaviour
{

    private bool grabbed;

    private void Update()
    {
        grabbed = transform.parent.GetComponent<GrabBox>().grabbed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "HeavyBox" || col.transform.tag == "LightBox")
        {
            if (!grabbed)
            {
                col.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.transform.tag == "HeavyBox" || col.transform.tag == "LightBox")
        {
            col.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }
}

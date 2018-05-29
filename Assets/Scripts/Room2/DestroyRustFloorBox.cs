using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRustFloorBox : MonoBehaviour
{
    public bool activate;

    // Use this for initialization
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "HeavyBox")
        {
            if (col.transform.GetComponent<Rigidbody2D>().velocity.y <= -15)
            {
                activate = true;
            }
        }
    }
}

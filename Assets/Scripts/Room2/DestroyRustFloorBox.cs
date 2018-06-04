using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRustFloorBox : MonoBehaviour
{
    public bool activate1;
    public bool activate2;
    public bool activate3;

    // Use this for initialization
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "HeavyBox")
        {
            if (col.transform.GetComponent<Rigidbody2D>().velocity.y != 0 
                || col.transform.GetComponent<Rigidbody2D>().velocity.x != 0)
            {
                if (transform.parent.transform.parent.name == "RustFloor")
                {
                    activate1 = true;
                }
                if (transform.parent.transform.parent.name == "RustFloor2")
                {
                    activate2 = true;
                }
                if (transform.parent.transform.parent.name == "RustWall")
                {
                    activate3 = true;
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableYMovement : MonoBehaviour
{

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Terrain")
        {
            transform.parent.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | 
                RigidbodyConstraints2D.FreezeRotation;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Terrain")
        {
            transform.parent.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}

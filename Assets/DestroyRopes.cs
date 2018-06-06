using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRopes : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Ropes")
        {
            Destroy(col.gameObject);
        }
    }
}

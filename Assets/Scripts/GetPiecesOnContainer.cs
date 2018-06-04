using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPiecesOnContainer : MonoBehaviour {

    public bool isOnContainer;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "HeavyBoxPiece3")
        {
            isOnContainer = true;
            //col.GetComponent<Rigidbody2D>().isKinematic = true;
            col.transform.SetParent(transform.parent);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "HeavyBoxPiece3")
        {
            isOnContainer = false;
            col.transform.SetParent(null);
            //col.GetComponent<Rigidbody2D>().isKinematic = false;
        }
    }
}

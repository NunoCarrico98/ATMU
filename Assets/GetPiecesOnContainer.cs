using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPiecesOnContainer : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "HeavyBoxPiece3")
        {
            Debug.Log("FUCK");
            //col.GetComponent<Rigidbody2D>().isKinematic = true;
            col.transform.SetParent(transform.parent);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "HeavyBoxPiece3")
        {
            Debug.Log("OOPS");
            col.transform.SetParent(null);
            //col.GetComponent<Rigidbody2D>().isKinematic = false;
        }
    }
}

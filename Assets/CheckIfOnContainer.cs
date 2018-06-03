using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfOnContainer : MonoBehaviour {

    public bool isOnContainer;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "GetPiecesCollider")
        {
            isOnContainer = true;
            //col.GetComponent<Rigidbody2D>().isKinematic = true;
            transform.SetParent(col.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.name == "GetPiecesCollider")
        {
            isOnContainer = false;
            transform.SetParent(null);
            //col.GetComponent<Rigidbody2D>().isKinematic = false;
        }
    }
}

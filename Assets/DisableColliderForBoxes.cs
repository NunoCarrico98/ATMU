using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableColliderForBoxes : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "DeathZone")
        {
            transform.Find("ColliderForBoxes").GetComponent<Collider2D>().enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "DeathZone")
        {
            transform.Find("ColliderForBoxes").GetComponent<Collider2D>().enabled = true;
        }
    }
}

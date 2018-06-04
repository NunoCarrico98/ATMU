using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableFloorCollider : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            if (transform.parent.name == "FloorRoom6")
            {
                transform.parent.gameObject.SetActive(false);
            }
        }
    }
}

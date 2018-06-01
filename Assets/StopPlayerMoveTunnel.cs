using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPlayerMoveTunnel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player" && name == "StopPlayerMove")
        {
            col.GetComponent<PlayerMovement>().characterAnim.SetFloat("Speed", 0);
            col.GetComponent<PlayerMovement>().enabled = false;
        }
        if (col.tag == "Player" && name == "ResetPlayerMove")
        {
            col.GetComponent<PlayerMovement>().characterAnim.SetFloat("Speed", 0);
            col.GetComponent<PlayerMovement>().enabled = true;
        }
    }
}

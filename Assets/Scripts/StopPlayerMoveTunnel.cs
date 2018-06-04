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
        if(col.tag == "Player" && (name == "StopPlayerMove" || name == "StopPlayerMove2"))
        {
            col.GetComponent<PlayerMovement>().enabled = false;
            col.GetComponent<PlayerMovement>().characterAnim.SetFloat("Speed", 0);
            col.GetComponent<PlayerMovement>().characterAnim.SetBool("Ground", true);
            //col.GetComponent<PlayerMovement>().characterAnim.Play("IdleAnim");
        }
        if (col.tag == "Player" && name == "ResetPlayerMove")
        {
            col.GetComponent<PlayerMovement>().enabled = true;
        }
    }
}

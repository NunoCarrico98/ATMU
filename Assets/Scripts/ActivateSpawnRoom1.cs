using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSpawnRoom1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player") {
            transform.parent.Find("SpawnPoint").GetComponent<SpawnBoxHooksRoom1>().enabled = true;
        }
    }
}

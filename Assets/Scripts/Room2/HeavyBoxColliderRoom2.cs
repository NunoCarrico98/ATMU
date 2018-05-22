using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyBoxColliderRoom2 : MonoBehaviour {

    private FloorCollider floorCollider;

	// Use this for initialization
	void Start () {
        floorCollider = FindObjectOfType<FloorCollider>();
	}

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "HeavyBox")
        {
            floorCollider.greenLight = false;
        }
    }

}

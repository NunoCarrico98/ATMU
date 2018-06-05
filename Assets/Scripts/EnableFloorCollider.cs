using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableFloorCollider : MonoBehaviour {

    public Transform floorPrefab;

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
                //transform.parent.gameObject.SetActive(false);
                Destroy(transform.parent.gameObject);
            }
            if (transform.parent.name == "NewFloorRoom6")
            {
                //transform.parent.gameObject.SetActive(false);
                //Instantiate(floorPrefab)
            }
        }
    }
}

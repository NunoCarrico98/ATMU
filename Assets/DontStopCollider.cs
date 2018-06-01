using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontStopCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "HeavyBoxPiece" || col.tag == "HeavyBoxPiece2" || col.tag == "HeavyBoxPiece3")
        {
            if (name == "DontStopCollider")
            {
                col.transform.position = Vector3.MoveTowards(col.transform.position, Vector3.right, 10 * Time.deltaTime);
            }
            if(name == "StopAcceleration")
            {
                col.transform.position = Vector3.MoveTowards(col.transform.position, 
                    new Vector3(col.transform.position.x, col.transform.position.y + 1, col.transform.position.z),
                    10 * Time.deltaTime);
            }

            if (name == "StopAcceleration2")
            {
                col.transform.position = Vector3.MoveTowards(col.transform.position,
                    new Vector3(col.transform.position.x - 1, col.transform.position.y, col.transform.position.z),
                    25 * Time.deltaTime);
            }
            if (name == "StopAcceleration3")
            {
                col.transform.position = Vector3.MoveTowards(col.transform.position,
                    new Vector3(col.transform.position.x - 1, col.transform.position.y, col.transform.position.z),
                    30 * Time.deltaTime);
            }
            if (name == "LimitsCollider")
            {
                Destroy(col.gameObject);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RustFloorCollider : MonoBehaviour {

    public GameObject rustFloor;
    public GameObject ragdollPrefab;
    public GameObject collider1;
    public GameObject collider2;

    private PlayerMovement pMove;
    private Transform parent;
    private int counter = 0;

	// Use this for initialization
	void Start () {
        parent = transform.parent.transform;
        pMove = FindObjectOfType<PlayerMovement>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            if (counter == 0 && pMove.grounded)
            {
                //col.transform.position = new Vector2(parent.position.x, parent.position.y + 5);
                Instantiate(ragdollPrefab, new Vector2(parent.position.x, parent.position.y - 3), parent.rotation);
                Destroy(rustFloor);
                Destroy(collider1);
                Destroy(collider2);
                counter++;
            }

        }
    }
}

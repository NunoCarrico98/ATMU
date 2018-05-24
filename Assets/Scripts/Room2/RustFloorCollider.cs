using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RustFloorCollider : MonoBehaviour {

    public GameObject rustFloor;
    public GameObject ragdollPrefab;
    public GameObject collider1;
    public GameObject collider2;

    private DestroyRustFloorBox box;
    private PlayerMovement pMove;
    private Transform parent;
    private int counter = 0;
    private float timer = 0;

	// Use this for initialization
	void Start () {
        parent = transform.parent.transform;
        pMove = FindObjectOfType<PlayerMovement>();
        box = FindObjectOfType<DestroyRustFloorBox>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            if ((counter == 0 && pMove.grounded) || box.activate)
            {
                if(timer < 0.1f) timer += Time.deltaTime;
                if (timer > 0.05f)
                {
                    //col.transform.position = new Vector2(parent.position.x, parent.position.y + 5);
                    Instantiate(ragdollPrefab, new Vector2(parent.position.x, parent.position.y), parent.rotation);
                    Destroy(rustFloor);
                    Destroy(collider1);
                    Destroy(collider2);
                    counter++;
                }
            }

        }
    }
}

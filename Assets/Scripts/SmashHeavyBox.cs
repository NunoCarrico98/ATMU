using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashHeavyBox : MonoBehaviour {


    public GameObject prefabRagdoll;
    public GameObject smallerRag;
    public GameObject tinyRag;
    public Transform ragParent;

    private GameObject[] pieces = new GameObject[9];
    private GameObject box;
    private Vector2 velocity;
    private float angularVelocity;
    private bool activate = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (activate)
        {
            for (int i = 0; i < pieces.Length; i++)
            {
                pieces[i] = prefabRagdoll.transform.GetChild(i).gameObject;
                pieces[i].GetComponent<Rigidbody2D>().velocity = velocity;
                pieces[i].GetComponent<Rigidbody2D>().angularVelocity = angularVelocity;
                if (i == pieces.Length - 1) activate = false;
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "HeavyBox")
        {
            box = col.gameObject;
            GetVelocity();
            Destroy(col.gameObject);
            Instantiate(prefabRagdoll, col.transform.position, transform.rotation);
            
            activate = true;
        }

        if(col.tag == "HeavyBoxPiece" && transform.parent.name != "Destroyer (1)")
        {
            box = col.gameObject;
            GetVelocity();
            Instantiate(smallerRag, col.transform.position, transform.rotation);
            Destroy(col.gameObject);
        }

        if (col.tag == "HeavyBoxPiece2" && transform.parent.name != "Destroyer (1)" && transform.parent.name != "Destroyer (2)")
        {
            box = col.gameObject;
            GetVelocity();
            Instantiate(tinyRag, col.transform.position, transform.rotation, ragParent);
            Destroy(col.gameObject);
        }
    }

    private void GetVelocity()
    {
        velocity = box.GetComponent<Rigidbody2D>().velocity;
        angularVelocity = box.GetComponent<Rigidbody2D>().angularVelocity;
    }
}

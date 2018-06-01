using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTunnelDoor : MonoBehaviour {

    public Transform parent;
    public float speed = 10f;

    private bool open = false;
    private Vector3 openVector;
    private Vector3 closeVector;


	// Use this for initialization
	void Start () {
        openVector = new Vector3(parent.position.x - 2, parent.position.y, parent.position.z);
        closeVector = new Vector3(parent.position.x, parent.position.y, parent.position.z);
    }
	
	// Update is called once per frame
	void Update () {
        if (open)
        {
            Open();
        } else
        {
            Close();
        }
	}

    private void Open()
    {
        parent.position = Vector3.MoveTowards(parent.position, openVector, speed * Time.deltaTime);
    }

    private void Close()
    {
        parent.position = Vector3.MoveTowards(parent.position, closeVector, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "LightBox")
        {
            Debug.Log("WORKED!!");
            if (col.transform.name == "Container")
            {
                
                open = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "LightBox")
        {
            if (col.transform.name == "Container")
            {
                Debug.Log("WORKED!!");
                open = false;
            }
        }
    }
}

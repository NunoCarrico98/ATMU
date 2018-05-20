using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnaceDoor : MonoBehaviour {

    public float openSpeed = 50f;

    public bool open = false;
    private Quaternion lookRotation;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Open();
	}

    private void Open()
    {
        if (open == true)
        {
            //transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);
            lookRotation = Quaternion.LookRotation(Vector3.forward, Vector3.left);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, openSpeed * Time.deltaTime);
            //transform.rotation = Quaternion.
        }
    }
}

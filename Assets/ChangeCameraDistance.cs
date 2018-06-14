using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraDistance : MonoBehaviour {

    public float speed;

    private Transform cam;
    private bool entered = false;
    private bool isBig = false;
    private bool isSmall = true;
    private float size;
    private float resetSize;

	// Use this for initialization
	void Start () {
        size = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().orthographicSize;
	}
	
	// Update is called once per frame
	void Update () {

		if(entered && !isBig)
        {
            if (size < 20)
            {
                size += speed * Time.deltaTime;

                isSmall = false;

                if (size >= 20)
                {
                    size = 20;
                    isBig = true;
                }

                cam.GetComponent<Camera>().orthographicSize = size;
            }
        }

        if(!entered && !isSmall)
        {
            if (size > resetSize)
            {
                size -= speed * Time.deltaTime;

                isBig = false;

                if (size <= resetSize)
                {
                    size = resetSize;
                    isSmall = true;
                }

                cam.GetComponent<Camera>().orthographicSize = size;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            cam = col.transform.Find("MainCamera");
            resetSize = cam.GetComponent<Camera>().orthographicSize;
            entered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            cam = col.transform.Find("MainCamera");
            entered = false;
        }
    }
}

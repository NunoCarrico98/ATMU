using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerOnOff : MonoBehaviour {

    public bool on;
    public float speed = 20f;

    private Vector3 downVector;
    private Vector3 upVector;
    private bool up = true;
    private bool down = false;

    // Use this for initialization
    void Start () {
        upVector = new Vector3(transform.position.x, 90, transform.position.z);
        downVector = new Vector3(transform.position.x, 86, transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if(on)
        {
            DestroyActivated();
        } else
        {
            GoUp();
        }
    }

    private void DestroyActivated()
    {
        if(up && !down)
        {
            GoDown();
        }
        if(down && !up)
        {
            GoUp();
        }
    }

    private void GoUp()
    {
        transform.position = Vector3.MoveTowards(transform.position, upVector, speed * Time.deltaTime);
        if (transform.position == upVector)
        {
            down = false;
            up = true;
        }
    }

    private void GoDown()
    {
        transform.position = Vector3.MoveTowards(transform.position, downVector, speed * Time.deltaTime);
        if (transform.position == downVector)
        {
            up = false;
            down = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.transform.tag == "HeavyBox" || col.transform.tag == "LightBox")
        {
            down = true;
            up = false;
        }
    }
}

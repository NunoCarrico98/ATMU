using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ByeShip : MonoBehaviour {

    public GameObject box;
    public float counter = 2f;

    private bool stop = false;

	// Use this for initialization
	void Start () {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().gravityScale = 0;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().stopHorizontalMovement = true;
        box.GetComponent<Rigidbody2D>().gravityScale = 0;

    }
	
	// Update is called once per frame
	void Update () {


        transform.position = Vector3.MoveTowards(transform.position,
            new Vector3(1000, transform.position.y, transform.position.z), 20 * Time.deltaTime);

        counter -= Time.deltaTime;

        if(counter <= 0.2f && !stop)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().gravityScale = 10;
        }
        if (counter <= 0f && !stop)
        {
            box.GetComponent<Rigidbody2D>().gravityScale = 10;
            stop = true;
        }

        if(counter <= -1.85f)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().stopHorizontalMovement = false;
        }


        if (transform.position == new Vector3(1000, transform.position.y, transform.position.z))
        {
            Destroy(gameObject);
        }
	}
}

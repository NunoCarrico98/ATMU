using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ByeShip : MonoBehaviour {

    public GameObject box;
    public GameObject blackCanvas;
    public float fadeSpeed;
    public float counter = 2f;

    private Color blackColor;
    private bool stop = false;

	// Use this for initialization
	void Start () {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().gravityScale = 0;
        GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().stopHorizontalMovement = true;
        Camera.main.GetComponent<CameraFollow>().enabled = false;
        box.GetComponent<Rigidbody2D>().gravityScale = 0;
        box.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;

    }
	
	// Update is called once per frame
	void Update () {

        blackColor = blackCanvas.GetComponent<SpriteRenderer>().color;
        blackColor.a -= fadeSpeed * Time.deltaTime;
        blackCanvas.GetComponent<SpriteRenderer>().color = blackColor;

        transform.position = Vector3.MoveTowards(transform.position,
            new Vector3(1000, transform.position.y, transform.position.z), 20 * Time.deltaTime);

        counter -= Time.deltaTime;

        if(counter <= 0.2f && !stop)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().gravityScale = 10;
            GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
            Camera.main.GetComponent<CameraFollow>().enabled = true;

        }
        if (counter <= 0f && !stop)
        {
            box.GetComponent<Rigidbody2D>().gravityScale = 10;
            box.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
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

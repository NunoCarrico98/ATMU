using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBox : MonoBehaviour {

    public Transform wayPoint;
    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "HeavyBox")
        {
            if(collision.GetComponent<Rigidbody2D>().isKinematic == false)
            {
                collision.transform.position = Vector2.MoveTowards(collision.transform.position,
                    new Vector2(wayPoint.transform.position.x, collision.transform.position.y),
                    speed * Time.deltaTime);
            }
        }
    }
}

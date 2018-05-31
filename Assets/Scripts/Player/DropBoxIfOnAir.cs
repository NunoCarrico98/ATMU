using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBoxIfOnAir : MonoBehaviour
{
    public bool boxFoundCollider = false;
    public float distance = 2f;

    private Transform player;
    private GameObject box;
    private Collider2D boxCollider;
    private bool grounded = false;

    // Use this for initialization
    void Start()
    {
        boxCollider = transform.parent.GetComponent<BoxCollider2D>();
        player = GameObject.Find("Player").transform;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "HeavyBox" || col.transform.tag == "LightBox" || col.transform.tag == "Terrain")
        {
            if (player.GetComponent<GrabBox>().grabbed)
            {
                //if box is heigher than the player
                //if (transform.parent.position.y > player.position.y)
                //{
                    boxFoundCollider = true;
                //}
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.transform.tag == "HeavyBox" || col.transform.tag == "LightBox" || col.transform.tag == "Terrain")
        {
            boxFoundCollider = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        grounded = player.GetComponent<PlayerMovement>().grounded;
        box = player.GetComponent<GrabBox>().box;
        IsGrounded();

        if (player.GetComponent<GrabBox>().grabbed == false)
        {
            transform.GetComponent<Collider2D>().enabled = false;
            boxFoundCollider = false;
        } else
        {
            transform.GetComponent<Collider2D>().enabled = true;
        }
    }

    private void IsGrounded()
    {
        if (!grounded)
        {
            if (boxFoundCollider)
            {
                player.GetComponent<GrabBox>().boxCollider.GetComponent<Collider2D>().enabled = false;
                box.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                box.GetComponent<Rigidbody2D>().isKinematic = false;
                box.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
                box.GetComponent<Collider2D>().enabled = true;
                boxCollider.enabled = false;
                player.GetComponent<GrabBox>().grabbed = false;
            }
        }
    }
}

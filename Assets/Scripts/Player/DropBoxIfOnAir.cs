using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBoxIfOnAir : MonoBehaviour
{
    public bool boxFoundCollider = false;

    private Transform player;
    private GameObject box;
    private Collider2D boxCollider;
    private bool grounded = false;

    // Use this for initialization
    void Start()
    {
        boxCollider = transform.parent.GetComponent<Collider2D>();
        player = GameObject.Find("Player").transform;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "HeavyBox" || col.transform.tag == "LightBox" || col.transform.tag == "Terrain")
        {
            if (player.GetComponent<GrabBox>().grabbed)
            {
                if (box.GetComponent<Collider2D>().enabled == false)
                {
                    boxFoundCollider = true;
                }
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

        if (player.GetComponent<GrabBox>().grabbed == true && box.name != "Container")
        {
            if (name == "DropBoxCollider")
            {
                transform.GetComponent<Collider2D>().enabled = true;
            }

        }
        if (player.GetComponent<GrabBox>().grabbed == true && box.name == "Container")
        {
            if (name == "DropContainerCollider")
            {
                transform.GetComponent<Collider2D>().enabled = true;
            }

        }
        if (player.GetComponent<GrabBox>().grabbed == false)
        {
            transform.GetComponent<Collider2D>().enabled = false;
            boxFoundCollider = false;

        }

    }

    private void IsGrounded()
    {
        if (!grounded)
        {
            if (boxFoundCollider && player.GetComponent<GrabBox>().grabbed)
            {
                //boxCollider.enabled = false;
                if (box != null)
                {
                    if (box.name != "Container" && box.name != "Crate1" && box.name != "Crate2")
                    {
                        boxCollider.GetComponent<Collider2D>().enabled = false;
                        box.transform.Find("ColliderForBoxes").transform.GetComponent<Collider2D>().enabled = true;
                        box.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                        box.GetComponent<Rigidbody2D>().isKinematic = false;
                        box.GetComponent<Rigidbody2D>().velocity = new Vector3(box.GetComponent<Rigidbody2D>().velocity.x, 0, 0);
                        box.GetComponent<Collider2D>().enabled = true;
                    }
                    if (box.name == "Crate1" || box.name == "Crate2")
                    {
                        boxCollider.GetComponent<Collider2D>().enabled = false;
                        box.transform.Find("ColliderForBoxes").transform.GetComponent<Collider2D>().enabled = true;
                        box.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                        box.GetComponent<Rigidbody2D>().isKinematic = false;
                        box.GetComponent<Rigidbody2D>().velocity = new Vector3(box.GetComponent<Rigidbody2D>().velocity.x, 0, 0);
                        box.GetComponent<Collider2D>().enabled = true;
                    }
                    if (box.name == "Container")
                    {
                        boxCollider.GetComponent<Collider2D>().enabled = false;
                        box.transform.Find("ColliderForBoxes").transform.GetComponent<Collider2D>().enabled = true;
                        box.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                        box.GetComponent<Rigidbody2D>().isKinematic = false;
                        box.GetComponent<Rigidbody2D>().velocity = new Vector3(box.GetComponent<Rigidbody2D>().velocity.x, 0, 0);
                        box.GetComponent<PolygonCollider2D>().enabled = true;
                        box.transform.SetParent(null);
                    }
                }
                player.GetComponent<GrabBox>().keyCount = 0;
                player.GetComponent<GrabBox>().grabbed = false;
            }
        }
    }
}

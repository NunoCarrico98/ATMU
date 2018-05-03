using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCheck : MonoBehaviour
{
    public bool foundBox = false;
    public float distance = 2f;
    public float angle;
    public GameObject player;
    public Vector2 offset;

    private RaycastHit2D[] hitUp = new RaycastHit2D[3];
    private int count = 0;
    private Vector2 resetOffset;

    // Use this for initialization
    void Start()
    {
        offset = transform.Find("ColliderSide").GetComponent<Collider2D>().offset;
        resetOffset = offset;
    }

    // Update is called once per frame
    void Update()
    {
        angle = player.GetComponent<GrabBox>().angle;

        FlipBoxCollider();

        hitUp[0] = Physics2D.Raycast(transform.position - new Vector3(0.7f, 0, 0), Vector2.up, distance);
        hitUp[1] = Physics2D.Raycast(transform.position, Vector2.up, distance);
        hitUp[2] = Physics2D.Raycast(transform.position + new Vector3(0.7f, 0, 0), Vector2.up, distance);

        /* Detect collision to up raycast */
        if ((hitUp[0].collider != null && hitUp[0].collider.tag == "BoxColliders") ||
            (hitUp[1].collider != null && hitUp[1].collider.tag == "BoxColliders") ||
            (hitUp[2].collider != null && hitUp[2].collider.tag == "BoxColliders"))
        {
            foundBox = true;
            player.GetComponent<GrabBox>().box.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            player.GetComponent<GrabBox>().box.GetComponent<Collider2D>().enabled = true;
            player.GetComponent<GrabBox>().grabbed = false;
        }
        if (hitUp[0].collider == null || hitUp[1].collider == null || hitUp[2].collider == null)
        {
            foundBox = false;
        }
    }


   /* private void BreakBox()
    {
        if(transform.tag == "HeavyBox")
        {
            if(transform.GetComponent<Collider2D>().bounds.Intersects())
        }
    }*/


    private void OnTriggerEnter2D(Collider2D col)
    {
        /*if(col.collider.tag == "HeavyBox" && this.tag == "LightBox")
        {
            Destroy(this.gameObject);
        }*/

        if (col.gameObject.tag == "HeavyBox" && this.transform.Find("ColliderForBoxes").GetComponent<Collider2D>().tag == "BoxCollider")
        {
            Destroy(this.gameObject, 0.05f);
        }

    }

    public void FlipBoxCollider()
    {
        if (angle < -90 || angle > 90 && count == 1)
        {
            transform.Find("ColliderSide").GetComponent<Collider2D>().offset = resetOffset;
        }

        if (angle > -90 && angle < 90)
        {
            count = 1;
            transform.Find("ColliderSide").GetComponent<Collider2D>().offset = -offset;
        }
    }
}

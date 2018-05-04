using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCheck : MonoBehaviour
{
    public bool foundBox = false;
    public float distance = 2f;
    public float angle;

    private RaycastHit2D[] hitUp = new RaycastHit2D[3];
    private GameObject player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        angle = player.GetComponent<GrabBox>().angle;

        hitUp[0] = Physics2D.Raycast(transform.position - new Vector3(0.7f, 0, 0), Vector2.up, distance);
        hitUp[1] = Physics2D.Raycast(transform.position, Vector2.up, distance);
        hitUp[2] = Physics2D.Raycast(transform.position + new Vector3(0.7f, 0, 0), Vector2.up, distance);

        /* Detect collision to up raycast */
        if ((hitUp[0].collider != null && hitUp[0].collider.tag == "BoxColliders") ||
            (hitUp[1].collider != null && hitUp[1].collider.tag == "BoxColliders") ||
            (hitUp[2].collider != null && hitUp[2].collider.tag == "BoxColliders"))
        {
            foundBox = true;
            player.GetComponent<GrabBox>().boxCollider.GetComponent<Collider2D>().enabled = false;
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
}

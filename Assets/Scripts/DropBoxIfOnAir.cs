using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBoxIfOnAir : MonoBehaviour
{
    public bool boxFoundCollider = false;
    public float distance = 2f;
    public float angle;

    private RaycastHit2D[] hitDown = new RaycastHit2D[3];
    private GameObject box;

    private bool grounded = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        box = GetComponent<GrabBox>().box;
        grounded = GetComponent<PlayerMovement>().grounded;

        hitDown[0] = Physics2D.Raycast(box.transform.position - new Vector3(0.7f, 0, 0), Vector2.down, distance);
        hitDown[1] = Physics2D.Raycast(box.transform.position, Vector2.down, distance);
        hitDown[2] = Physics2D.Raycast(box.transform.position + new Vector3(0.7f, 0, 0), Vector2.down, distance);

        CastRaycastDown();
        IsGrounded();
    }

    private void CastRaycastDown()
    {
        /* Detect collision to up raycast */
        if (hitDown[0].collider != null || hitDown[1].collider != null || hitDown[2].collider != null)
        {
            if ((hitDown[0].collider.tag == "HeavyBox" || hitDown[0].collider.tag == "LightBox" || hitDown[0].collider.tag == "Terrain") ||
                (hitDown[1].collider.tag == "HeavyBox" || hitDown[1].collider.tag == "LightBox" || hitDown[1].collider.tag == "Terrain") ||
                (hitDown[2].collider.tag == "HeavyBox" || hitDown[2].collider.tag == "LightBox" || hitDown[2].collider.tag == "Terrain"))
            {
                if (box.transform.position.y > transform.position.y)
                {
                    boxFoundCollider = true;
                }
            }
        }

        if (hitDown[0].collider == null && hitDown[1].collider == null && hitDown[2].collider == null)
        {
            boxFoundCollider = false;
        }
    }

    private void IsGrounded()
    {
        if (!grounded)
        {
            if (boxFoundCollider)
            {
                GetComponent<GrabBox>().boxCollider.GetComponent<Collider2D>().enabled = false;
                box.GetComponent<Rigidbody2D>().isKinematic = false;
                box.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
                box.GetComponent<Collider2D>().enabled = true;
                GetComponent<GrabBox>().grabbed = false;
            }
        }
    }
}

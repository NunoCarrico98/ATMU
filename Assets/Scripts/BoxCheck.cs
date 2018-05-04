﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCheck : MonoBehaviour
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
        grounded = GetComponent<CharacterMovement>().grounded;

        hitDown[0] = Physics2D.Raycast(box.transform.position - new Vector3(0.7f, 0, 0), Vector2.down, distance);
        hitDown[1] = Physics2D.Raycast(box.transform.position, Vector2.down, distance);
        hitDown[2] = Physics2D.Raycast(box.transform.position + new Vector3(0.7f, 0, 0), Vector2.down, distance);

        CastRaycastOnGround();
        IsGrounded();
    }

    private void CastRaycastOnGround()
    {
        /* Detect collision to up raycast */
        if (hitDown[0].collider != null || hitDown[1].collider != null || hitDown[2].collider != null)
        {
            if (box.transform.position.y > transform.position.y)
            {
                boxFoundCollider = true;
            }
        }

        if (hitDown[0].collider == null || hitDown[1].collider == null || hitDown[2].collider == null)
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

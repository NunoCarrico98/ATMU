﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabBox : MonoBehaviour
{

    private int keyCount = 0;
    private float xMouse;
    private float yMouse;
    private Transform rotateBoxPoint;
    private bool facingRight;
    private bool crouched = false;
    private Rigidbody2D playerRb;


    public Vector2 positionOnScreen;
    public Vector2 mouseOnScreen;
    public Vector2 direction;
    public bool grabbed;
    public RaycastHit2D hit;
    public RaycastHit2D hitBack;
    public float distance = 2f;
    public float distanceBack = 2f;
    public Transform holdpoint;
    public float throwforce;
    public LayerMask notgrabbed;
    public float angle;
    public int angleOffSet = 0;
    public LayerMask notToHit;
    public GameObject box;
    public bool backBoxR = false;
    public bool backBoxL = false;
    public Transform boxCollider;
    public Transform boxParent;

    // Use this for initialization
    void Start()
    {
        boxCollider = GameObject.Find("Player").transform.Find("BoxCollider").transform;
    }

    // Update is called once per frame
    void Update()
    {

        crouched = GetComponent<PlayerMovement>().crouched;

        facingRight = GetComponent<PlayerMovement>().facingRight;

        FollowMouse();

        direction = DirectionVector(positionOnScreen, mouseOnScreen);
        direction = CreateVersor(direction);

        rotateBoxPoint = transform.Find("RotateBoxPoint");

        Physics2D.queriesStartInColliders = false;

        BackRayHitsNothing();


        if (!grabbed)
        {

            //If player is facing left create a raycast pointing left
            if (angle > -30 && angle < 90 /*90*/)
            {
                hit = Physics2D.Raycast(transform.position, Vector2.left, distance);
            }

            //If player is facing right create a raycast pointing right

            if ((angle < 180 && angle > 90) || (angle < -150/*-90*/ && angle > -180))
            {
                hit = Physics2D.Raycast(transform.position, Vector2.right, distance);
            }

            //Raycast that follows mouse position on top side
            if (angle <= -30 && angle >= -150)
            {
                hit = Physics2D.Raycast(transform.position, direction, distance * 1.5f);
            }
        }

        if (Input.GetButtonDown("Fire2") && !crouched)
        {
            if (!grabbed)
            {
                //If raycast detects a grabbable object
                if (hit.collider != null && (hit.collider.tag == "HeavyBox" || hit.collider.tag == "LightBox"))
                {
                    grabbed = true;
                }
            }
        }

        if (grabbed)
        {
            box = hit.collider.gameObject;
            box.transform.position = holdpoint.position;            //box goes to the position of a hold point in front of the character
            boxCollider.position = holdpoint.position;
            boxCollider.GetComponent<Collider2D>().enabled = true;
            box.transform.Find("ColliderForBoxes").transform.GetComponent<Collider2D>().enabled = false;
            box.GetComponent<Rigidbody2D>().isKinematic = true;
            box.GetComponent<Collider2D>().enabled = false;         //disable collider 
            box.transform.SetParent(boxParent);

            FireBackRaycastGround();
            BackRayHits();

            if (box.GetComponent<Rigidbody2D>() != null)
            {
                direction = DirectionVector(positionOnScreen, mouseOnScreen);
                direction = CreateVersor(direction);

                if (Input.GetButtonUp("Fire2"))
                {
                    keyCount += 1;
                    if (keyCount >= 2)
                    {
                        keyCount = 2;
                    }
                }

                if ((Input.GetButtonUp("Fire2") && keyCount == 2) || crouched)
                {
                    boxCollider.GetComponent<Collider2D>().enabled = false;
                    box.transform.Find("ColliderForBoxes").transform.GetComponent<Collider2D>().enabled = true;
                    box.GetComponent<Rigidbody2D>().isKinematic = false;
                    box.GetComponent<Rigidbody2D>().velocity = new Vector3(box.GetComponent<Rigidbody2D>().velocity.x, 0, 0);
                    box.GetComponent<Collider2D>().enabled = true;
                    grabbed = false;
                    keyCount = 0;
                }

                if (Input.GetButtonDown("Fire1"))
                {
                    boxCollider.GetComponent<Collider2D>().enabled = false;
                    box.transform.Find("ColliderForBoxes").transform.GetComponent<Collider2D>().enabled = true;
                    box.GetComponent<Rigidbody2D>().isKinematic = false;
                    box.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
                    box.GetComponent<Collider2D>().enabled = true;
                    box.GetComponent<Rigidbody2D>().AddForce(direction * throwforce, ForceMode2D.Impulse);
                    grabbed = false;
                    keyCount = 0;
                }
            }
        }
    }

    private void FireBackRaycastGround()
    {
        //If character is facing left draws a raycast pointing to it's back
        if (facingRight == false)
        {
            hitBack = Physics2D.Raycast(transform.position, Vector2.right, distanceBack);
        }

        //If character is facing right draws a raycast pointing to it's back
        if (facingRight == true)
        {
            hitBack = Physics2D.Raycast(transform.position, Vector2.left, distanceBack);
        }
    }

    private void BackRayHits()
    {
        if (hitBack.collider != null && grabbed)
        {
            if (facingRight)
            {
                backBoxR = false;
                backBoxL = true;

                if (angle <= -95 || (angle < 180 && angle > 0))
                {
                    rotateBoxPoint.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 180f + 170f));
                }
            }
            else
            {
                backBoxR = true;
                backBoxL = false;

                if (angle >= -55 && angle < 180)
                {
                    rotateBoxPoint.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 15f + 170f));
                }
            }

        }
    }

    private void BackRayHitsNothing()
    {
        backBoxR = false;
        backBoxL = false;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawLine(transform.position, holdpoint.position);
    }


    public void FollowMouse()
    {
        //Get the Screen positions of the object
        positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        //Get the Screen position of the mouse
        mouseOnScreen = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
        angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
    }

    public float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        float xA = Mathf.Abs(a.x);
        float xB = Mathf.Abs(b.x);
        float yA = Mathf.Abs(a.y);
        float yB = Mathf.Abs(b.y);
        return Mathf.Atan2(yA - yB, xA - xB) * Mathf.Rad2Deg;
    }

    public Vector2 DirectionVector(Vector2 a, Vector2 b)
    {
        float xA = a.x;
        float xB = b.x;
        float yA = a.y;
        float yB = b.y;

        return (new Vector2((xB - xA), (yB - yA)));
    }

    public Vector2 CreateVersor(Vector2 a)
    {
        float norm = Mathf.Sqrt(Vector3.Dot(a, a));

        return a / norm;
    }
}

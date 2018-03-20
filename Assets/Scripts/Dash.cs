﻿using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;
using UnityStandardAssets._2D;

public class Dash : MonoBehaviour
{

    [SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character
    [SerializeField] public int keyCountRight = 0;
    [SerializeField] public int keyCountLeft = 0;
    [SerializeField] public float timer = 0;
    [SerializeField] public float timer2 = 0;
    [SerializeField] public float secondTimer;

    private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
    private bool m_Grounded;            // Whether or not the player is grounded.
    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    public int groundTrue = 0;
    public float oldPos;
    public float newPos;
    public float maxDistance = 3f;
    public float newPositionTimeCheck = 2f;
    public bool facingRight = true;

    private Rigidbody2D myRigidBody2D;
    private Vector2 vectorForDash = new Vector2(1, 0);
    public float dashSpeed = 1f;
    public float givenTime = 1;

    // Use this for initialization
    void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
        m_GroundCheck = transform.Find("GroundCheck");
    }

    private void FixedUpdate()
    {
        m_Grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                m_Grounded = true;

            if (m_Grounded == true)
            {
                groundTrue = 1;
            }
            else
            {
                groundTrue = 0;
            }

            /*if (myRigidBody2D.velocity.y * Time.deltaTime > 0)
            {
                jumpCount++;
            }
            if(jumpCount) */
        }
    }

    // Update is called once per frame
    void Update()
    {
        vectorForDash = new Vector2(dashSpeed, 0);
        //A timer that is constantly working
        timer += Time.deltaTime;
        /*timer2 += Time.deltaTime;

        if (timer2 > newPositionTimeCheck)
        {
            timer2 = 0;
        }
        if (timer <= newPositionTimeCheck)
        {
            newPos = myRigidBody2D.position.x;
        }*/

        //In this function we force the player too (CONTINUAR AMANHÃ)

        if (Input.GetKeyDown(KeyCode.D))
        {
;
            keyCountRight++;
            secondTimer = timer;
            keyCountLeft = 0;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            keyCountLeft++;
            secondTimer = timer;
            keyCountRight = 0;
        }

        //Reset number of presses on both keys
        if (timer - secondTimer > givenTime)
        {
            keyCountRight = 0;
            keyCountLeft = 0;
            GetComponent<Platformer2DUserControl>().enabled = true;
        }

        //Reset number of presses on the D key
        if (keyCountRight > 2)
        {
            keyCountRight = 0;
            GetComponent<Platformer2DUserControl>().enabled = true;
        }
        //Reset number of presses on the A key
        if (keyCountLeft > 2)
        {
            keyCountLeft = 0;
            GetComponent<Platformer2DUserControl>().enabled = true;
        }

        //Dash right by double pressing the Space key (within the given time)
        if (keyCountRight == 2 && (timer - secondTimer < givenTime))
        {
            //oldPos = myRigidBody2D.position.x;
            GetComponent<Platformer2DUserControl>().enabled = false;
            myRigidBody2D.AddRelativeForce(vectorForDash, ForceMode2D.Impulse);
        }

        //Dash right by double pressing the Space key (within the given time)
        if (keyCountLeft == 2 && (timer - secondTimer < givenTime))
        {
            //oldPos = myRigidBody2D.position.x;
            GetComponent<Platformer2DUserControl>().enabled = false;
            myRigidBody2D.AddRelativeForce(-1 * vectorForDash, ForceMode2D.Impulse);
        }

        /*if (newPos - oldPos > maxDistance)
        {
            myRigidBody2D.velocity.Set(0, myRigidBody2D.velocity.y);
            //myRigidBody2D.position.x = oldPos + maxDistance;
        }*/
            //myRigidBody2D.velocity = -transform.right * dashSpeed;
        } 
}
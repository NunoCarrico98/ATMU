using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;
using UnityStandardAssets._2D;

public class DashNotUpToDate : MonoBehaviour {

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

    private Rigidbody2D myRigidBody2D;
    private Vector2 vectorForDash = new Vector2(1, 0);
    public float dashSpeed = 1f;
    public float givenTime = 1;

    // Use this for initialization
    void Start ()
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
        }
    }

    // Update is called once per frame
    void Update()
    {
        vectorForDash = new Vector2(dashSpeed, 0);

        //In this function we force the player too (CONTINUAR AMANHÃ)
        if (Input.GetKeyDown(KeyCode.D))
        {
            keyCountLeft = 0;
            keyCountRight++;
            secondTimer = timer;
        }

        //Reset number of presses on the D key
        if (timer - secondTimer > givenTime)
        {
            keyCountRight = 0;
            GetComponent<Platformer2DUserControl>().enabled = true;
        }

        //Reset number of presses on the D key
        if (keyCountRight > 2)
        {
            keyCountRight = 0;
            GetComponent<Platformer2DUserControl>().enabled = true;
        }

        //Dash right when on ground by double pressing the D key (within the given time)
        if (keyCountRight == 2 /*&& groundTrue == 1*/ && (timer - secondTimer < givenTime))
        {
            //oldPos = myRigidBody2D.position.x;
            GetComponent<Platformer2DUserControl>().enabled = false;
            myRigidBody2D.AddRelativeForce(vectorForDash, ForceMode2D.Impulse);
        }

        //Count number of times player presses A and reset number of times player presses D
        if (Input.GetKeyDown(KeyCode.A))
        {
            keyCountRight = 0;
            secondTimer = timer;
            keyCountLeft++;
        }

        //Dash left when on ground by double pressing the A key (within the given time)
        if (keyCountLeft == 2 /*&& groundTrue == 1*/ && (timer - secondTimer < givenTime))
        {
            GetComponent<Platformer2DUserControl>().enabled = false;
            myRigidBody2D.AddRelativeForce(-1 * vectorForDash, ForceMode2D.Impulse);
            //myRigidBody2D.velocity = -transform.right * dashSpeed;
        }
        //Reset number of presses on the A key
        if (timer - secondTimer > givenTime)
        {
            keyCountLeft = 0;
            GetComponent<Platformer2DUserControl>().enabled = true;
            //myRigidBody2D.velocity = transform.right * dashSpeed;

        }
        //Reset number of presses on the A key
        if (keyCountLeft > 2)
        {
            keyCountLeft = 0;
            GetComponent<Platformer2DUserControl>().enabled = true;
        }
        //Reset timer so it doesn't get to big
        if (timer > 999)
        {
            timer = 0;
        }
    }

    /* Update is called once per frame
    void Update ()
    {
        //In this function we force the player too (CONTINUAR AMANHÃ)
        if (Input.GetKeyUp(KeyCode.D))
        {
            time = timeReset;
            keyCountRight++;
        }
        if(keyCountRight == 2 && groundTrue == 1)
        {
            //myRigidBody2D.AddForce(dashSpeed, ForceMode2D.Impulse);
            myRigidBody2D.velocity = transform.right * dashSpeed;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            time = timeReset;
            keyCountLeft++;
        }
        if (keyCountLeft == 2 && groundTrue == 1)
        {
            //myRigidBody2D.AddForce(dashSpeed, ForceMode2D.Impulse);
            myRigidBody2D.velocity = -transform.right * dashSpeed;
        }
        time -= Time.deltaTime;
        if (time <= 0)
        {
            time = timeReset;
            keyCountRight = 0;
            keyCountLeft = 0;
        }

    } */
}

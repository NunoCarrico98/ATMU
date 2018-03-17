using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour {

    [SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character

    private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
    private bool m_Grounded;            // Whether or not the player is grounded.
    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    public int groundTrue = 0;

    public Rigidbody2D myRigidBody2D;
    //public Vector2 dashSpeed = new Vector2(15, 0);
    public float dashSpeed = 2f;
    private float newPos;
    public int keyCountRight = 0;
    public int keyCountLeft = 0;
    public float time = 1;
    public float timeReset;

    // Use this for initialization
    void Start ()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
        m_GroundCheck = transform.Find("GroundCheck");
        newPos = myRigidBody2D.velocity.x;
        timeReset = time;
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

            /*if (myRigidBody2D.velocity.y * Time.deltaTime > 0)
            {
                jumpCount++;
            }
            if(jumpCount) */
        }
    }

    // Update is called once per frame
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

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPack : MonoBehaviour {

    [SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character

    private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
    private bool m_Grounded;            // Whether or not the player is grounded.
    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded

    public Rigidbody2D myRigidBody2D;
    public float ascendingSpeed = 10f;
    //public Vector2 ascendingSpeed = new Vector2(0, 10);
    private Vector2 force;
    private float h;

    public float timer = 0.5f;          //Time that the player can fly with the jetpack
    private float addToTimer;           //Restarter for the timer
    public int jumpCount = 0;           //Variable to check if the player has jumped already

    void Start ()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
        m_GroundCheck = transform.Find("GroundCheck");
        addToTimer = timer;         //We attribute 'timer's initial value to 'addToTimer'
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

            /*if (myRigidBody2D.velocity.y * Time.deltaTime > 0)    
            {
                jumpCount++;
            }
            if(jumpCount) */
        }
    }
    void Update ()
    {
        h = myRigidBody2D.velocity.x;
        force = new Vector2(h , ascendingSpeed);
        

        if (Input.GetKeyUp(KeyCode.Space) || myRigidBody2D.velocity.y < 0)
        {
            jumpCount++;
        }

        if (jumpCount > 0 )
        {
            if (Input.GetKey(KeyCode.Space) && timer > 0)
            {
                timer -= Time.deltaTime;
                //myRigidBody2D.MovePosition((Vector3)myRigidBody2D.position + transform.up * ascendingSpeed);
                myRigidBody2D.velocity = force;
            }
            //Reset timer and jump count
            if (m_Grounded == true)
            {
                timer = addToTimer;
                jumpCount = 0;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;
using UnityStandardAssets._2D;

public class DashV2 : MonoBehaviour
{

    [SerializeField] private LayerMask m_WhatIsGround;      // A mask determining what is ground to the character
    private int keyCount = 0;
    public int numberOfPresses = 2;
    private float timer = 0;
    private float secondTimer;

    private Transform m_GroundCheck;        // A position marking where to check if the player is grounded.
    private bool m_Grounded;                // Whether or not the player is grounded.
    const float k_GroundedRadius = .2f;     // Radius of the overlap circle to determine if grounded
    private bool facingRight = true;

    private Rigidbody2D myRigidBody2D;
    private Vector2 vectorForDash = new Vector2(1, 0);
    public float dashSpeed = 1f;
    public float clickTime = 1;
    public float cooldown = 0.5f;
    private bool activateCooldown = false;
    private float pressTime;
    public bool onlyDashOnGround = false;

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
        }
        vectorForDash = new Vector2(dashSpeed, 0);
        //A timer that is constantly working
        timer += Time.deltaTime;

        //In this function we force the player too (CONTINUAR AMANHÃ)
        if (Input.GetKeyDown(KeyCode.A))
        {
            facingRight = false;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            facingRight = true;
        }


        if (Input.GetKeyDown(KeyCode.LeftShift) && activateCooldown == false)
        {
            keyCount++;
            secondTimer = timer;
        }

        //Reset number of presses on the Shift key
        if (timer - secondTimer > clickTime)
        {
            keyCount = 0;
            GetComponent<Platformer2DUserControl>().enabled = true;
        }

        //Reset number of presses on the Shift key
        if (keyCount > numberOfPresses)
        {
            keyCount = 0;
            GetComponent<Platformer2DUserControl>().enabled = true;
        }

        if (onlyDashOnGround == false)
        {
            //Dash right by double pressing the Shift key (within the given time)
            if (keyCount == numberOfPresses && (timer - secondTimer < clickTime) && facingRight == true)
            {
                GetComponent<Platformer2DUserControl>().enabled = false;
                myRigidBody2D.AddForce(vectorForDash, ForceMode2D.Impulse);
                pressTime = timer;
                activateCooldown = true;
            }

            //Dash left by double pressing the Shift key (within the given time)
            if (keyCount == numberOfPresses && (timer - secondTimer < clickTime) && facingRight == false)
            {
                GetComponent<Platformer2DUserControl>().enabled = false;
                myRigidBody2D.AddForce(-1 * vectorForDash, ForceMode2D.Impulse);
                pressTime = timer;
                activateCooldown = true;
            }
        }

        if (onlyDashOnGround == true)
        {
            //Dash right by double pressing the Shift key (within the given time)
            if (keyCount == numberOfPresses && (timer - secondTimer < clickTime) && facingRight == true && m_Grounded == true)
            {
                GetComponent<Platformer2DUserControl>().enabled = false;
                myRigidBody2D.AddForce(vectorForDash, ForceMode2D.Impulse);
                pressTime = timer;
                activateCooldown = true;
            }

            //Dash left by double pressing the Shift key (within the given time)
            if (keyCount == numberOfPresses && (timer - secondTimer < clickTime) && facingRight == false && m_Grounded == true)
            {
                GetComponent<Platformer2DUserControl>().enabled = false;
                myRigidBody2D.AddForce(-1 * vectorForDash, ForceMode2D.Impulse);
                pressTime = timer;
                activateCooldown = true;
            }
        }

        //Add a cooldown between dashes
        if (activateCooldown == true)
        {
            if (timer - pressTime > cooldown)
            {
                activateCooldown = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

using System;
using UnityEngine;

//namespace UnityStandardAssets._2D
//{
    public class PlatformerCharacter2D : MonoBehaviour
    {
        [SerializeField] private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
        [SerializeField] private float m_JumpForce = 400f;                  // Amount of force added when the player jumps.
        [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;  // Amount of maxSpeed applied to crouching movement. 1 = 100%
        [SerializeField] private bool m_AirControl = false;                 // Whether or not a player can steer while jumping;
        [SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character

        private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
        const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
        private bool m_Grounded;            // Whether or not the player is grounded.
        private Transform m_CeilingCheck;   // A position marking where to check for ceilings
        const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
        private Animator m_Anim;            // Reference to the player's animator component.
        private Rigidbody2D m_Rigidbody2D;
        public bool m_FacingRight = true;  // For determining which way the player is currently facing.
        public float sprintSpeed = 2f;
        //private float m_SpeedReset;
        public bool sprint = true;

        public float angle;
        public Vector2 positionOnScreen;
        public Vector2 mouseOnScreen;

        private Transform playerGraphics;
        private Transform playerHead;
        private Transform boxHoldPoint;

        private void Awake()
        {
            // Setting up references.
            m_GroundCheck = transform.Find("GroundCheck");
            m_CeilingCheck = transform.Find("CeilingCheck");
            m_Anim = GetComponent<Animator>();
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
            //m_SpeedReset = m_MaxSpeed; ;
            playerGraphics = transform.Find("Graphics");
            playerHead = transform.Find("RotatingHead");
            /*boxHoldPoint = transform.Find("BoxHoldPoint");
            if (boxHoldPoint == null)
            {
                Debug.LogError("Let's panic!! There's no 'Graphics' object as a child of the player");
            }*/
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
            m_Anim.SetBool("Ground", m_Grounded);

            // Set the vertical animation
            m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);
        }


        public void Move(float move, bool crouch, bool jump)
        {
            // If crouching, check to see if the character can stand up
            if (!crouch && m_Anim.GetBool("Crouch"))
            {
                // If the character has a ceiling preventing them from standing up, keep them crouching
                if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
                {
                    crouch = true;
                }
            }

            // Set whether or not the character is crouching in the animator
            m_Anim.SetBool("Crouch", crouch);

            //only control the player if grounded or airControl is turned on
            if (m_Grounded || m_AirControl)
            {
                // Reduce the speed if crouching by the crouchSpeed multiplier
                move = (crouch ? move*m_CrouchSpeed : move);

                // The Speed animator parameter is set to the absolute value of the horizontal input.
                m_Anim.SetFloat("Speed", Mathf.Abs(move));

                // Move the character
                /*if (sprint == true)
                {
                    if (Input.GetKeyDown(KeyCode.LeftShift) && m_Grounded)
                    {
                        m_MaxSpeed = sprintSpeed;
                    }

                    if (Input.GetKeyUp(KeyCode.LeftShift) && m_Grounded)
                    {
                        m_MaxSpeed = m_SpeedReset;
                    }
                }*/

                m_Rigidbody2D.velocity = new Vector2(move * m_MaxSpeed, m_Rigidbody2D.velocity.y);

                positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
                mouseOnScreen = Camera.main.ScreenToViewportPoint(Input.mousePosition);
                angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
                // If the input is moving the player right and the player is facing left...
                if (m_FacingRight == true && (angle > -90 && angle < 90))
                {
                    // ... flip the player.
                    Flip();
                }
                if (m_FacingRight == false && (angle < -90 || angle > 90))
                {
                    // ... flip the player.
                    Flip();
                }

                //Flip player accordingly to it's head rotation
                /*if (angle < -90 || angle > 90)
                {
                    m_FacingRight = true;
                }*/
                /*if (angle > -90 && angle < 90)
                {
                    m_FacingRight = false;
                }*/

            }
            // If the player should jump...
            if (m_Grounded && jump && m_Anim.GetBool("Ground"))
            {
                // Add a vertical force to the player.
                m_Grounded = false;
                m_Anim.SetBool("Ground", false);
                m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
            }
        }


        private void Flip()
        {
            // Switch the way the player is labelled as facing.
            m_FacingRight = !m_FacingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = playerGraphics.localScale;
            theScale.x *= -1;
            playerGraphics.localScale = theScale;

            Vector3 theScale2 = playerHead.localScale;
            theScale2.y *= -1;
            playerHead.localScale = theScale2;

           /*Vector3 theScale3 = boxHoldPoint.localScale;
            theScale3.x *= -1;
            boxHoldPoint.localScale = theScale3;*/
        }

        float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
        {
            return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
        }

    }
//}

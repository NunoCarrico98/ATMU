using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public LayerMask whatIsGround;
    public Transform groundCheckPoint;
    public bool facingRight;
    public bool jumpRequest;
    public bool grounded;
    public float groundCheckRadius;

    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float jumpForce = 600f;

    private Rigidbody2D myRigidbody2D;
    private Transform playerGraphics;
    private Transform playerHead;
    public Animator characterAnim;

    private float resetSpeed;
    private float angle = 0f;
    private bool backBoxR;
    private bool backBoxL;

    // Use this for initialization
    private void Awake()
    {
        facingRight = true;
        grounded = false;

        myRigidbody2D = GetComponent<Rigidbody2D>();
        characterAnim = GetComponent<Animator>();
        playerGraphics = transform.Find("Graphics");
        playerHead = transform.Find("RotatingHead");

        resetSpeed = movementSpeed;
    }

    private void Update()
    {
        SetJumpRequest();
        IsGrounded();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Movement();
        FlipPlayer();
        Jump();
        Crouch();
    }

    private void Movement()
    {
        // Move Player
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal * movementSpeed, myRigidbody2D.velocity.y);
        myRigidbody2D.velocity = movement;

        // Set movement animation
        characterAnim.SetBool("Ground", grounded);

        // Set the vertical animation
        characterAnim.SetFloat("vSpeed", myRigidbody2D.velocity.y);

        // The Speed animator parameter is set to the absolute value of the horizontal input.
        characterAnim.SetFloat("Speed", Mathf.Abs(moveHorizontal));
    }

    private void SetJumpRequest()
    {
        // Check input 
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            // if on the ground
            if (grounded)
            {
                // Ask for jump
                jumpRequest = true;
            }
        }
    }

    private void Jump()
    {
        if (jumpRequest)
        {
            // Character jumps
            Vector2 jump = new Vector2(0f, jumpForce);
            myRigidbody2D.AddForce(jump);

            jumpRequest = false;

            // Set jumping animation
            characterAnim.SetBool("Ground", false);
        }
    }

    private void Crouch()
    {

        if (grounded && (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.LeftControl)))
        {
            movementSpeed = 0;
            characterAnim.SetBool("Crouch", true);
        }
        else
        {
            movementSpeed = resetSpeed;
            characterAnim.SetBool("Crouch", false);
        }
    }

    private void IsGrounded()
    {
        // Verify if player is touching the ground
        grounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheckPoint.position, groundCheckRadius);
    }

    private void FlipPlayer()
    {
        // Get angle bewtween mouse and player
        angle = GetComponent<GrabBox>().angle;

        // Get if player has a box behind him
        backBoxR = GetComponent<GrabBox>().backBoxR;
        backBoxL = GetComponent<GrabBox>().backBoxL;

        // If the input is moving the player right and the player is facing left...
        if (facingRight && (angle > -90 && angle < 90) && !backBoxL)
        {
            // ... flip the player.
            Flip();
        }
        if (!facingRight && (angle < -90 || angle > 90) && !backBoxR)
        {
            // ... flip the player.
            Flip();
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Flip the player's body.
        Vector3 theScale = playerGraphics.localScale;
        theScale.x *= -1;
        playerGraphics.localScale = theScale;

        // Flip the player's head
        Vector3 theScale2 = playerHead.localScale;
        theScale2.x *= -1;
        playerHead.localScale = theScale2;
    }
}

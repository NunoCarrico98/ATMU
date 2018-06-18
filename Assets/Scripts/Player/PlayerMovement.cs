using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator characterAnim;
    public Transform boxHoldPoint;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;
    public bool facingRight;
    public bool jumpRequest;
    public bool grounded;
    public bool crouched = false;
    public bool stopHorizontalMovement = false;
    public float timeToFallAsleep;
    public float groundCheckRadius;

    [SerializeField] public float movementSpeed = 10f;
    [SerializeField] public float jumpForce = 600f;

    private Rigidbody2D myRigidbody2D;
    private Transform playerGraphics;
    private Transform playerHead;

    private Quaternion initRotation;
    private PlayerConveyorBelt conveyor;
    private GrabBox grabBox;

    private float resetBoxPosition;
    private float resetSpeed;
    private float angle = 0f;
    private float timer = 0;
    private bool backBoxR;
    private bool backBoxL;
    public bool isSleeping;
    private bool wakeUp;

    // Use this for initialization
    private void Awake()
    {
        facingRight = true;
        grounded = true;

        initRotation = transform.rotation;

        myRigidbody2D = GetComponent<Rigidbody2D>();
        characterAnim = GetComponent<Animator>();
        playerGraphics = transform.Find("Graphics");
        playerHead = transform.Find("RotatingHead");

        conveyor = FindObjectOfType<PlayerConveyorBelt>();
        grabBox = FindObjectOfType<GrabBox>();

        resetSpeed = movementSpeed;
    }

    private void Update()
    {
        if (transform.rotation != initRotation)
        {
            transform.rotation = initRotation;
        }

        SetJumpRequest();
        IsGrounded();

        PutToSleep();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!isSleeping)
        {
            Movement();
            FlipPlayer();
            Jump();
        }

        //Crouch();
    }

    private void PutToSleep()
    {
        if (!Input.anyKey && Input.GetAxis("Mouse X") == 0 && Input.GetAxis("Mouse Y") == 0)
        {
            if (!isSleeping)
            {
                timer += Time.deltaTime;
            }
        }
        else
        {
            if (!isSleeping)
            {
                timer = 0;
            }
        }

        if (timer >= timeToFallAsleep)
        {
            isSleeping = true;
            characterAnim.SetBool("Sleeping", isSleeping);


            if (Input.anyKey || Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            {
                wakeUp = true;
                timer = 0;
            }
        }
        if (wakeUp)
        {
            timer += Time.deltaTime;
            characterAnim.SetBool("Sleeping", false);
            if (timer > 0.8f)
            {
                isSleeping = false;
                wakeUp = false;
                timer = 0;
                ;
            }
        }

    }

    private void Movement()
    {
        // Move Player
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal * movementSpeed, myRigidbody2D.velocity.y);

        if (!conveyor.isOnBox)
        {
            if (conveyor.isOnConveyor && grounded)
            {
                movement = new Vector2(moveHorizontal * movementSpeed + conveyor.conveyorSpeed - 9.9f, myRigidbody2D.velocity.y);
            }
        }
        else
        {
            if (conveyor.isOnConveyor && grounded)
            {
                movement = new Vector2(moveHorizontal * movementSpeed + conveyor.conveyorSpeed - 10f, myRigidbody2D.velocity.y);
            }
        }

        if (!stopHorizontalMovement)
        {
            myRigidbody2D.velocity = movement;
        }

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
        //if (Input.GetButtonDown("Jump"))
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
            myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, 0f);
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
            crouched = true;
        }
        else
        {
            movementSpeed = resetSpeed;
            characterAnim.SetBool("Crouch", false);
            crouched = false;
        }
    }

    private void IsGrounded()
    {
        // Verify if player is touching the ground
        //grounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);
        grounded = Physics2D.OverlapBox(groundCheckPoint.position, new Vector2(1f, 0.4f), 0, whatIsGround);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(groundCheckPoint.position, new Vector2(1f, 0.4f));
    }

    private void FlipPlayer()
    {
        // Get angle bewtween mouse and player
        angle = grabBox.angle;

        // Get if player has a box behind him
        backBoxR = grabBox.backBoxR;
        backBoxL = grabBox.backBoxL;

        // If the input is moving the player right and the player is facing left...
        if (facingRight && (angle > -90 && angle < 90))
        {
            if (!backBoxL || (backBoxL && (angle > -90 && angle < -55)))
            {
                Flip();
            }
        }

        if (!facingRight && (angle < -90 || angle > 90))
        {
            if (!backBoxR || (backBoxR && (angle < -90 && angle > -95)))
            {
                Flip();
            }
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

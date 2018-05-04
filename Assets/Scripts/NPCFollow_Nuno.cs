using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFollow_Nuno : MonoBehaviour
{
    public Transform playerT;

    public float distanceFromPlayer;
    public float followSpeed;

    private GameObject playerGO;
    private Vector2 targetPos;
    private Vector2 lastGroundPos;
    private Rigidbody2D npcRigigbody;
    private Rigidbody2D playerRigigbody;

    private bool playerFacingRight;
    private bool playerJump;
    private bool playerAtRight = true;
    private bool playerAtLeft = false;
    private bool grounded = true;
    private int counter = 0;

    // Use this for initialization
    void Start()
    {
        npcRigigbody = this.gameObject.GetComponent<Rigidbody2D>();
        playerRigigbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerFacingRight = playerT.GetComponent<CharacterMovement>().facingRight;
        playerJump = playerT.GetComponent<CharacterMovement>().jumpRequest;
        grounded = playerT.GetComponent<CharacterMovement>().grounded;

        IsPlayerJumping();
        Rotate();
        Follow();
    }

    private void Follow()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, followSpeed * Time.deltaTime);
    }

    private void IsPlayerJumping()
    {
        if (!playerJump && grounded)
        {
            GetTargetPosition();
            lastGroundPos = transform.position;
        }
        else
        {
            
            GetTargetPosition();
        }
    }

    private void GetTargetPosition()
    {
        if (playerRigigbody.velocity.x > 0)
        {
            SetPositionLeft();
        }
        else if (playerRigigbody.velocity.x < 0)
        {
            SetPositionRight();
        }
        else
        {
            if (playerFacingRight)
            {
                SetPositionLeft();
            }
            else
            {
                SetPositionRight();
            }
        }
    }

    private void SetPositionLeft()
    {
        targetPos = new Vector2(playerT.position.x - distanceFromPlayer, playerT.position.y - lastGroundPos.y);
    }

    private void SetPositionRight()
    {
        targetPos = new Vector2(playerT.position.x + distanceFromPlayer, playerT.position.y - lastGroundPos.y);
    }

    private void Rotate()
    {

        if (transform.position.x - playerT.position.x <= 0) //if player is at right
        {
            playerAtRight = true;
            playerAtLeft = false;
        }
        else if (transform.position.x - playerT.position.x > 0) //if player is at left
        {
            playerAtLeft = true;
            playerAtRight = false;
        }

        if (playerAtRight && counter == 1)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 360, 0));
        }
        if (playerAtLeft)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            counter = 1;
        }
    }
}

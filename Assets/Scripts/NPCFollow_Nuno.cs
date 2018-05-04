using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFollow_Nuno : MonoBehaviour
{
    public GameObject playerGO;
    public Transform playerT;

    public float distanceFromPlayer;
    public float followSpeed;

    private Vector2 targetPos;
    private Rigidbody2D npcRigigbody;
    private Rigidbody2D playerRigigbody;

    private bool playerFacingRight;
    private bool playerJump;

    // Use this for initialization
    void Start()
    {
        npcRigigbody = this.gameObject.GetComponent<Rigidbody2D>();
        playerRigigbody = playerGO.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerFacingRight = playerT.GetComponent<CharacterMovement>().facingRight;
        playerJump = playerT.GetComponent<CharacterMovement>().jumpRequest;

        IsPlayerJumping();
        Follow();
    }

    private void IsPlayerJumping()
    {
        if (!playerJump)
        {
            GetTargetPosition();
        }
    }

    private void Follow()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, followSpeed * Time.deltaTime);
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
        targetPos = new Vector2(playerT.position.x - distanceFromPlayer, playerT.position.y);
    }

    private void SetPositionRight()
    {
        targetPos = new Vector2(playerT.position.x + distanceFromPlayer, playerT.position.y);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerAI : MonoBehaviour
{

    public float followingDelay;
    public float movementSpeed = 3f;
    public float maxSpeed = 10f;
    public float rotationSpeed;
    public float increaseSpeedWithDistance;
    public float distanceFromPlayer = 3f;
    public float detectionDistance = 20f;

    private Transform player;
    private bool foundObstacle = false;
    private Vector3 lookPos;
    private Quaternion rotation;
    private float currentSpeed;
    private float distance;
    private bool playerAtRight = true;
    private bool playerAtLeft = false;
    private int counter = 0;
    private bool grounded = true;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        distance = Mathf.Abs(transform.position.x - player.position.x);
        /*lookPos = player.position - transform.position;
        lookPos.y = 0;
        rotation = Quaternion.LookRotation(lookPos);
        rotation *= Quaternion.Euler(0, 180, 0);*/
        Rotate();
        ChangeSpeed();

        if (!foundObstacle)
        {
            if (distance > distanceFromPlayer && grounded)
            {
                //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
                //if(playerAtRight) transform.position += transform.right * currentSpeed * Time.deltaTime;
                //if(playerAtLeft) transform.position += transform.right * -1 * currentSpeed * Time.deltaTime;

                transform.position += transform.right * movementSpeed * Time.deltaTime;
            }
            //transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x - distanceFromPlayer, transform.position.y, transform.position.z), movementSpeed * Time.deltaTime);
        }
    }

    void Rotate()
    {

        if (transform.position.x - player.position.x <= 0) //if player is at right
        {
            playerAtRight = true;
            playerAtLeft = false;
        }
        else if (transform.position.x - player.position.x > 0) //if player is at left
        {
            playerAtLeft = true;
            playerAtRight = false;
        }

        if (playerAtRight && counter == 1)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 360, 0));
        }
        if(playerAtLeft)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            counter = 1;
        }
    }

    void ChangeSpeed()
    {
            //currentSpeed = movementSpeed * 0.3f * (Mathf.Clamp01(distance / detectionDistance)) * maxSpeed;
    }
}

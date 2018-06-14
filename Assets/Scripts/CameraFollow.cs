using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Vector3 offset;
    public float heightOffset = 5f;
    public float minRadius = 0.3f;
    public float fraction;
    [Range(0,1)]
    public float moveSpeed = 1f;
    public bool limitsOn = false;


    private Transform player;
    private GrabBox grabBox;
    private Vector3 direction;
    private float mouseRadius;
    private bool activateMove;
    private float newFraction = 5;
    private float minX;
    private float maxX;
    private float minY;
    private float maxY;
        

    //INICIO MIN x: = 9
    //INICIO MIN Y: 12
    
    //PUZZLE 7 MAX: 345


    // Use this for initialization
    void Start()
    {
        minX = 9;
        maxX = 1000;
        minY = 12;
        maxY = 1000;

        if (transform.parent.name == "Player")
        {
            player = GameObject.Find("Player").transform;
        }
        if(transform.parent.name == "PlayerRagdoll")
        {
            player = GameObject.FindGameObjectWithTag("PlayerRagdoll").transform;
        }

        grabBox = FindObjectOfType<GrabBox>();
    }

    private void Update()
    {
        if (name == "MainCamera") player = GameObject.Find("Player").transform;
        if (name == "RagdollCamera") player = transform.parent.GetChild(0);
        if (name == "MainCamera")
        {
            MoveCamera();
        }

        if (limitsOn)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY), transform.position.z);
        }
        //if (activateMove) MoveCamera();
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        Vector3 desiredPosition = (Vector3) player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, moveSpeed);
        transform.position = smoothedPosition;
    }


    private void OnMouseExit()
    {
        if(gameObject.name == "CameraMoveLimits")
        {
            activateMove = true;
        }
    }
    private void OnMouseEnter()
    {
        if (gameObject.name == "CameraMoveLimits")
        {
            activateMove = false;
        }
    }

    private void MoveCamera()
    {
        direction = grabBox.DirectionVector(grabBox.positionOnScreen, grabBox.mouseOnScreen);

        mouseRadius = Mathf.Sqrt(Mathf.Pow(direction.x, 2) + Mathf.Pow(direction.y, 2));

        if (mouseRadius > minRadius)
        {
            if (newFraction > 0.5)
            {
                newFraction = fraction / (mouseRadius * 10);
            }
            Vector3 moveVector = new Vector3(direction.x / newFraction, direction.y / newFraction, 0);

            if (transform.position != moveVector)
            {
                if ((direction.x > 0 && direction.y > 0) || (direction.x < 0 && direction.y < 0))
                {
                    transform.position += moveVector;
                }
                if ((direction.x > 0 && direction.y < 0) || (direction.x < 0 && direction.y > 0))
                {
                    transform.position += moveVector;
                }
            }
        }
    }
}

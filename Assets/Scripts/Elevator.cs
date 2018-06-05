using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Sprite[] elevSprites;
    public GameObject pressurePlate;
    public float elevatorSpeedUp = 5f;
    public float elevatorSpeedDown = 3f;
    public float distanceToMove = 10f;
    [Range(1, 2)] public float acceleration = 0.1f;

    private bool pressured;
    private bool elevatorUp;
    private bool elevatorDown;
    private int lastAction;
    private float currentSpeed;

    private Vector3 initialPos;
    private Vector3 endPos;

    // Use this for initialization
    private void Start()
    {
        lastAction = 1;
        currentSpeed = elevatorSpeedUp / 8;

        initialPos = transform.position;
        endPos = transform.position + Vector3.up * distanceToMove;
    }

    // Update is called once per frame
    private void Update()
    {
        pressured = pressurePlate.GetComponent<PressurePlate>().pressured;

        IsPressured();
        if (name != "BigElevator2")
        {
            ElevatorAnim();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "Player" && col.transform.parent == null
            && name != "BigElevator2")
        {
            col.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.transform.tag == "Player" && name != "BigElevator2")
        {
            col.transform.SetParent(null);
        }
    }

    private void ElevatorAnim()
    {
        if (lastAction == 0)
        {
           transform.GetComponent<SpriteRenderer>().sprite = elevSprites[2];
        }

        if (elevatorUp)
        {
            transform.GetComponent<SpriteRenderer>().sprite = elevSprites[1];
        }

        if(transform.position == endPos || transform.position == initialPos)
        {
            transform.GetComponent<SpriteRenderer>().sprite = elevSprites[0];
        }
    }

    private void IsPressured()
    {
        if (pressured)
        {
            lastAction = 1;
            if (lastAction == 1)
            {
                ElevatorAcceleration();
                transform.position = Vector3.MoveTowards(transform.position, endPos, currentSpeed * Time.deltaTime);
                elevatorUp = true;
            }
        }

        if (!pressured)
        {
            if (lastAction != 1)
            {
                ElevatorAcceleration();
                transform.position = Vector3.MoveTowards(transform.position, initialPos, currentSpeed * Time.deltaTime);
                if (transform.position == initialPos) elevatorDown = true;
            }

            if (elevatorUp)
            {
                lastAction = 0;
                elevatorUp = false;
                currentSpeed = elevatorSpeedDown / 8;
            }

            if (elevatorDown)
            {
                lastAction = 1;
                elevatorDown = false;
                currentSpeed = elevatorSpeedUp / 8;
            }
        }
    }

    private void ElevatorAcceleration()
    {
        if (lastAction == 1)
        {
            if (currentSpeed < elevatorSpeedUp)
            {
                currentSpeed *= acceleration;
            }
        }
        else
        {
            if (currentSpeed < elevatorSpeedDown)
            {
                currentSpeed *= acceleration;
            }
        }
    }
}

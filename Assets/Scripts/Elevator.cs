using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
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
    private Animator eleAnim;

    // Use this for initialization
    private void Start()
    {
        eleAnim = GetComponent<Animator>();

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
        ElevatorAnim();
    }

    private void ElevatorAnim()
    {
        if (elevatorDown || elevatorUp)
        {
            eleAnim.SetBool("Move", true);
        }

        if(transform.position == endPos)
        {
            eleAnim.SetBool("Move", false);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject pressurePlate;
    public float elevatorSpeed = 5f;
    public float distanceToMove = 10f;

    private bool pressured;
    private bool elevatorUp;
    private bool elevatorDown;
    private int lastAction;

    private Vector3 initialPos;
    //private Vector3 midPos;
    private Vector3 endPos;

    // Use this for initialization
    private void Start()
    {
        lastAction = 1;
        elevatorDown = false;
        elevatorUp = false;

        initialPos = transform.position;
        // midPos = transform.position + Vector3.up * distanceToMove;
        endPos = transform.position + Vector3.up * (2 * distanceToMove);
    }

    // Update is called once per frame
    private void Update()
    {
        pressured = pressurePlate.GetComponent<PressurePlate>().pressured;

        IsPressured();
        IsElevatorOn();
    }

    private void IsPressured()
    {
        if (pressured)
        {
            if (lastAction == 1)
            {
                elevatorUp = true;
            }
            else
            {
                elevatorDown = true;
            }
        }
    }

    private void IsElevatorOn()
    {
        if (elevatorUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, elevatorSpeed * Time.deltaTime);

            if (transform.position == endPos)
            {
                elevatorUp = false;
                lastAction = 0;
            }
        }

        if (elevatorDown)
        {
            transform.position = Vector3.MoveTowards(transform.position, initialPos, elevatorSpeed * Time.deltaTime);
            if (transform.position == initialPos)
            {
                elevatorDown = false;
                lastAction = 1;
            }
        }
    }
}

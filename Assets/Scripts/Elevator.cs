using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject pressurePlate;
    public float elevatorSpeed = 5f;
    public float distanceToMove = 10f;
    public float timerBeforeMove = 2f;

    private bool boxPressured;
    private bool playerPressured;
    private bool elevatorUp;
    private bool elevatorDown;
    private int lastAction;
    private float currentTime;

    private Vector3 initialPos;
    private Vector3 endPos;

    // Use this for initialization
    private void Start()
    {
        lastAction = 1;
        currentTime = 0;

        initialPos = transform.position;
        endPos = transform.position + Vector3.up * distanceToMove;
    }

    // Update is called once per frame
    private void Update()
    {
        boxPressured = pressurePlate.GetComponent<PressurePlate>().boxPressured;
        playerPressured = pressurePlate.GetComponent<PressurePlate>().playerPressured;

        IsPressured();
        StartTimer();
    }

    private void IsPressured()
    {
        if (playerPressured && !boxPressured)
        {
            if (lastAction == 1)
            {
                transform.position = Vector3.MoveTowards(transform.position, endPos, elevatorSpeed * Time.deltaTime);
                elevatorUp = true;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, initialPos, elevatorSpeed * Time.deltaTime);
                elevatorDown = true;
            }
        }

        if (boxPressured && !playerPressured)
        {
            if (lastAction == 1)
            {
                transform.position = Vector3.MoveTowards(transform.position, endPos, elevatorSpeed * Time.deltaTime);
                elevatorUp = true;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, initialPos, elevatorSpeed * Time.deltaTime);
                elevatorDown = true;
            }
        }

        if (!boxPressured && !playerPressured)
        {
            if (elevatorUp)
            {
                lastAction = 0;
                elevatorUp = false;
            }
            if (elevatorDown)
            {
                lastAction = 1;
                elevatorDown = false;
            }
        }
    }

    private void StartTimer()
    {
        if (transform.position == endPos)
        {
            currentTime += Time.deltaTime;

            if (currentTime >= timerBeforeMove)
            {
                lastAction = 0;
                currentTime = 0;
                elevatorUp = false;
            }
        }

        if (transform.position == initialPos)
        {
            currentTime += Time.deltaTime;

            if (currentTime >= timerBeforeMove)
            {
                lastAction = 1;
                currentTime = 0;
                elevatorDown = false;
            }
        }
    }
}

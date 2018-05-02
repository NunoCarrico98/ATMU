using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject pressurePlate;
    public float elevatorSpeed = 5f;
    public float distanceToMove = 10f;
    public float timerBeforeMove = 2f;

    private bool pressured;
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
        pressured = pressurePlate.GetComponent<PressurePlate>().pressured;

        IsPressured();
    }

    private void IsPressured()
    {
        if (pressured)
        {
            if (lastAction == 1)
            {
                transform.position = Vector3.MoveTowards(transform.position, endPos, elevatorSpeed * Time.deltaTime);
                StartTimer();
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, initialPos, elevatorSpeed * Time.deltaTime);
                StartTimer();
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
            }
        }

        if (transform.position == initialPos)
        {
            currentTime += Time.deltaTime;

            if (currentTime >= timerBeforeMove)
            {
                lastAction = 1;
                currentTime = 0;
            }
        }
    }
}

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
    private Vector3 endPos;

    // Use this for initialization
    private void Start()
    {
        lastAction = 1;

        initialPos = transform.position;
        endPos = transform.position + Vector3.up * distanceToMove;
    }

    // Update is called once per frame
    private void Update()
    {
        pressured = pressurePlate.GetComponent<PressurePlate>().pressured;

        IsPressured();
        //DisableRender();
    }

    private void IsPressured()
    {
        if (pressured)
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

        if (!pressured)
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

    private void DisableRender()
    {
        if(transform.position == endPos)
        {
            gameObject.SetActive(false);
        }
    }
}

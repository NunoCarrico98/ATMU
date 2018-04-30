using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject pressurePlate;
    public int howManyFloors = 1;
    public float howLongIsTrip = 10f;
    public float elevatorSpeed = 5f;

    private Vector2[] floors;

    private bool pressured;
    private bool goDown;
    private bool goUp;
    private int upFloor;
    private int downFloor;
    private int currentFloor;

    // Use this for initialization
    private void Start()
    {
        goUp = false;
        goDown = false;

        upFloor = 0;
        downFloor = howManyFloors;
        currentFloor = 0;

        floors[0] = transform.position;

        for (int i = 1; i <= howManyFloors; i++)
        {
            floors[i] = new Vector2(transform.position.x, floors[i - 1].y + howLongIsTrip);
        }

    }

    // Update is called once per frame
    private void Update()
    {
        pressured = pressurePlate.GetComponent<PressurePlate>().pressured;
        //SetCurrentFloor();
        IsPressured();
    }

    private void SetCurrentFloor()
    {
        if (transform.position.y == floors[upFloor].y)
        {
            currentFloor = upFloor;
            upFloor++;
            goUp = true;

            if (upFloor >= howManyFloors)
            {
                upFloor = howManyFloors;
            }
        }
        else if (transform.position.y == floors[downFloor].y)
        { 
            currentFloor = downFloor;
            downFloor--;
            goDown = true;

            if (downFloor <= 0)
            {
                downFloor = 0;
            }
        }
    }

    private void IsPressured()
    {
        if (pressured)
        {
            if(goUp)
            {
                transform.position = Vector2.MoveTowards(transform.position, floors[currentFloor + 1], elevatorSpeed * Time.deltaTime);
                goUp = false;
            }

            if(goDown)
            {
                transform.position = Vector2.MoveTowards(transform.position, floors[currentFloor - 1], elevatorSpeed * Time.deltaTime);
                goDown = false;
            }
        }
    }
}

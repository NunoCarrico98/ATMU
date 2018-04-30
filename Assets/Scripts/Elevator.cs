using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject pressurePlate;
    public float elevatorSpeed = 5f;
    public float distanceToMove = 10f;

    private bool pressured;

    private Vector3 initialPos;
    //private Vector3 midPos;
    private Vector3 endPos;

    // Use this for initialization
    private void Start()
    {
        initialPos = transform.position;
       // midPos = transform.position + Vector3.up * distanceToMove;
        endPos = transform.position + Vector3.up * (2 * distanceToMove);
    }

    // Update is called once per frame
    private void Update()
    {
        pressured = pressurePlate.GetComponent<PressurePlate>().pressured;
        //SetCurrentFloor();
        IsPressured();
    }

    private void IsPressured()
    {
        if (pressured)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, elevatorSpeed * Time.deltaTime);
        }
    }
}

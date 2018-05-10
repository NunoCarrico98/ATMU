using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private Vector3 initialPos;
    private Vector3 endPos;

    private bool pressured = false;

    public Transform pressurePlate;
    public float distance = 10;
    public float speed = 10; 

    // Use this for initialization
    void Start()
    {
        initialPos = transform.position;
        endPos = initialPos + Vector3.down * distance;
    }

    // Update is called once per frame
    void Update()
    {
        pressured = pressurePlate.GetComponent<PressurePlate>().pressured;

        if (pressured)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, initialPos, speed * Time.deltaTime);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public bool pressured;
    public float speed = 5f;
    public float distanceToMove = 10f;

    private Vector3 initialPos;
    private Vector3 endPos;

    private void Start()
    {
        pressured = false;

        initialPos = transform.position;
        endPos = transform.position + Vector3.down * distanceToMove;
    }

    private void Update()
    {
        MovePlateDown();
        MovePlateUp();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Grabbable" ||
            col.gameObject.tag == "Player" ||
            col.gameObject.tag == "Robot")
        {
            pressured = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        pressured = false;
    }

    private void MovePlateDown()
    {
        if (pressured)
        {
            if (transform.position == endPos)
            {
                transform.position = endPos;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
            }
        }
    }

    private void MovePlateUp()
    {
        if (!pressured)
        {
            if (transform.position == initialPos)
            {
                transform.position = initialPos;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, initialPos, speed * Time.deltaTime);
            }
        }
    }
}

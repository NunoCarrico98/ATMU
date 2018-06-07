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
    public bool openUp = false;
    public bool openDown = false;

    // Use this for initialization
    void Start()
    {
        initialPos = transform.position;

        GetEndPos();
    }

    // Update is called once per frame
    void Update()
    {
        pressured = pressurePlate.GetComponent<PressurePlate>().pressured;

        if (name != "DoorPuzzle8") {
            if (pressured)
            {
                transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, initialPos, speed / 2 * Time.deltaTime);
            }
        }

        if(name == "DoorPuzzle8")
        {
            if (Puzzle8Pressures.puzzleSolved)
            {
                if (pressured)
                {
                    transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
                }
            }
        }
    }

    private void GetEndPos()
    {
        if (openDown)
        {
            endPos = initialPos + Vector3.down * distance;
        }

        if (openUp)
        {
            endPos = initialPos + Vector3.up * distance;
        }
    }
}

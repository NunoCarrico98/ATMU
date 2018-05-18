using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigElevatorFall : MonoBehaviour
{
    public float smallFallSpeed;
    public float bigFallSpeed;
    [Range(1, 2)] public float acceleration = 0.1f;
    public float waitTime;
    public float endWaitTime;

    private bool smallFall;
    private bool bigFall;
    private float currentSpeed;

    private Vector3 midPos;
    private Vector3 endPos;
    private Transform player;
    private Transform elevator;
    private Transform colliderBigElev;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player").transform;
        elevator = GameObject.Find("BigElevator").transform;

        midPos = transform.parent.transform.parent.Find("BigElevatorsWaypoints").transform.Find("Waypoint2").transform.position;
        endPos = transform.parent.transform.parent.Find("BigElevatorsWaypoints").transform.Find("Waypoint3").transform.position;

        currentSpeed = smallFallSpeed;
    }

    // Update is called once per frame
    private void Update()
    {
        ElevatorFalls();
        ElevatorAcceleration();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Player")
        {
            smallFall = true;
        }
    }

    private void ElevatorFalls()
    {
        if (smallFall)
        {
            player.GetComponent<PlayerMovement>().characterAnim.SetFloat("Speed", 0);
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            player.transform.SetParent(elevator);

            elevator.GetComponent<SpringJoint2D>().enabled = false;
            elevator.GetComponent<Rigidbody2D>().isKinematic = true;

            elevator.transform.position = Vector3.MoveTowards(elevator.transform.position, midPos, smallFallSpeed * Time.deltaTime);

            if (elevator.transform.position == midPos)
            {
                elevator.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                smallFall = false;
                bigFall = true;
            }
        }

        if (bigFall)
        {
            StartCoroutine(MidTimer());
            StartCoroutine(EndTimer());
        }
    }

    private void ElevatorAcceleration()
    {
        if (bigFall)
        {
            if (elevator.position != midPos)
            {
                if (currentSpeed < bigFallSpeed)
                {
                    currentSpeed *= acceleration;
                }
            }
        }
    }

    private IEnumerator MidTimer()
    {
        yield return new WaitForSeconds(waitTime);
        elevator.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

        elevator.transform.position = Vector3.MoveTowards(elevator.transform.position, endPos, currentSpeed * Time.deltaTime);

        if (elevator.position == endPos)
        {
            elevator.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        }
    }

    private IEnumerator EndTimer()
    {
        yield return new WaitForSeconds(endWaitTime);

        if (elevator.position == endPos)
        {
            player.GetComponent<PlayerMovement>().enabled = true;
            player.transform.SetParent(null);
            bigFall = false;
        }
    }
}

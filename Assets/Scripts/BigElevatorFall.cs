using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigElevatorFall : MonoBehaviour
{
    public float smallFallSpeed;
    public float bigFallSpeed;
    [Range(1, 2)] public float acceleration = 0.1f;
    public float waitTime;

    private bool activateFall;
    private bool smallFall;
    private bool bigFall;
    private float currentSpeed;

    private Vector3 initialPos;
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
        colliderBigElev = transform.parent.transform.Find("ColliderBigElevator");

        initialPos = elevator.parent.transform.Find("Waypoint").transform.position;
        midPos = elevator.parent.transform.Find("Waypoint2").transform.position;
        endPos = elevator.parent.transform.Find("Waypoint3").transform.position;

        currentSpeed = smallFallSpeed;
    }

    // Update is called once per frame
    private void Update()
    {
        IsFallActive();
        ElevatorFalls();
        //ElevatorAcceleration();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Player")
        {
            smallFall = true;
        }
    }

    private void IsFallActive()
    {
        if (smallFall)
        {
            player.GetComponent<CharacterMovement>().characterAnim.SetFloat("Speed", 0);
            player.GetComponent<CharacterMovement>().enabled = false;
            player.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            player.transform.SetParent(elevator);
            // colliderBigElev.GetComponent<BoxCollider2D>().enabled = false;
            elevator.GetComponent<SpringJoint2D>().enabled = false;
            elevator.GetComponent<Rigidbody2D>().isKinematic = true;

            elevator.transform.position = Vector3.MoveTowards(elevator.transform.position, midPos, smallFallSpeed * Time.deltaTime);

            if (elevator.transform.position == midPos)
            {
                smallFall = false;
                bigFall = true;
            }

            if (elevator.transform.position == endPos)
            {
                bigFall = false;
                player.GetComponent<CharacterMovement>().enabled = true;
                player.transform.SetParent(null);
            }
        }
    }

    private void ElevatorFalls()
    {
        if (bigFall)
        {
            StartCoroutine(MidTimer());
        }
    }

    /*private void ElevatorAcceleration()
    {
        if (bigFall)
        {
            if (currentSpeed < bigFallSpeed)
            {
                currentSpeed *= acceleration;
            }
        }
    }*/

    private IEnumerator MidTimer()
    {
        yield return new WaitForSeconds(waitTime);
        elevator.transform.position = Vector3.MoveTowards(elevator.transform.position, endPos, currentSpeed * Time.deltaTime);
    }
}

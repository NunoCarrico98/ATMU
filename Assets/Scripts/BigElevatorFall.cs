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

    // Use this for initialization
    void Start()
    {
        initialPos = transform.parent.transform.Find("Waypoint").transform.position;
        midPos = transform.parent.transform.Find("Waypoint2").transform.position;
        endPos = transform.parent.transform.Find("Waypoint3").transform.position;

        player = GameObject.Find("Player").transform;

        currentSpeed = bigFallSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        IsFallActive();
        ElevatorFalls();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Player")
        {
            if (transform.position == initialPos)
            {
                col.transform.SetParent(transform.parent);
                activateFall = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.transform.tag == "Player")
        {
            col.transform.SetParent(null);
        }
    }

    private void IsFallActive()
    {
        if (activateFall)
        {
            player.GetComponent<CharacterMovement>().characterAnim.SetFloat("Speed", 0);
            player.GetComponent<CharacterMovement>().enabled = false;
            player.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);

            if (transform.position == initialPos)
            {
                smallFall = true;
            }

            if (transform.position == midPos)
            {
                smallFall = false;
                bigFall = true;
            }

            if (transform.position == endPos)
            {
                player.GetComponent<CharacterMovement>().enabled = true;
                activateFall = false;
            }
        }
    }

    private void ElevatorFalls()
    {
        if (smallFall)
        {
            transform.parent.position = Vector3.MoveTowards(transform.parent.position, midPos, smallFallSpeed * Time.deltaTime);
        }

        if (bigFall)
        {
            StartCoroutine(MidTimer());
        }
    }

    private void ElevatorAcceleration()
    {
        if (currentSpeed < bigFallSpeed)
        {
            currentSpeed *= acceleration;
        }
    }

    private IEnumerator MidTimer()
    {
        yield return new WaitForSeconds(waitTime);
        transform.parent.position = Vector3.MoveTowards(transform.parent.position, endPos, currentSpeed * Time.deltaTime);
        ElevatorAcceleration();
    }
}

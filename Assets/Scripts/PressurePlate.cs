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
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();

        pressured = false;

        initialPos = transform.position;
        endPos = transform.position + Vector3.down * distanceToMove;
    }

    private void Update()
    {
        //anim.SetBool("Pressured", pressured);
        MovePlate();
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

    private void MovePlate()
    {
        if (pressured)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
        }
        else if (transform.position == endPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, initialPos, speed * Time.deltaTime);
        }
        else
        {
            transform.position = initialPos;
        }
    }

}

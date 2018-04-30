using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public bool pressured;
    public float moveSpeed = 5f;

    private Vector2 upPos;
    private Vector2 downPos;
    private Animator anim;
    
    private void Start()
    {
        anim = GetComponent<Animator>();

        pressured = false;

        upPos = new Vector2(transform.position.x, transform.position.y);
        downPos = new Vector2(transform.position.x, transform.position.y - 5);
    }

    private void Update()
    {
        anim.SetBool("Pressured", pressured);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Grabbable" ||
            col.gameObject.tag == "Player" ||
            col.gameObject.tag == "Robot")
        {
            pressured = true;
            IsPressured();
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        pressured = false;
        IsPressured();
    }

    private void IsPressured()
    {
        if (pressured)
        {
            MovePressurePlateDown();
        }
        else
        {
            MovePressurePlateUp();
        }
    }

    private void MovePressurePlateDown()
    {
        transform.position = Vector2.MoveTowards(transform.position, downPos, moveSpeed * Time.deltaTime);
    }

    private void MovePressurePlateUp()
    {
        transform.position = Vector2.MoveTowards(transform.position, upPos, moveSpeed * Time.deltaTime);
    }
}

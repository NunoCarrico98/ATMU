using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public bool pressured;
    public float speed = 5f;
    public float distanceToMove = 10f;

   /* private Vector3 initialPos;
    private Vector3 endPos;*/
    private Animator plateAnim;
    private Collider2D colUp;
    private Collider2D colDown;

    private void Start()
    {
        plateAnim = GetComponent<Animator>();
        colUp = transform.Find("ColliderUp").GetComponent<BoxCollider2D>();
        colDown = transform.Find("ColliderDown").GetComponent<BoxCollider2D>();

        pressured = false;
        colUp.enabled = true;
        colDown.enabled = false;

        /*initialPos = transform.position;
        endPos = transform.position + Vector3.down * distanceToMove;*/
    }

    private void Update()
    {
        IsPressured();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" ||
            col.gameObject.tag == "HeavyBox" ||
            col.gameObject.tag == "LightBox")
        {
            pressured = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        pressured = false;
    }

    private void IsPressured()
    {
        if (pressured)
        {
            plateAnim.SetBool("PlateMove", true);
            colUp.enabled = false;
            colDown.enabled = true;
        }

        if (!pressured)
        {
            plateAnim.SetBool("PlateMove", false);
            colUp.enabled = true;
            colDown.enabled = false;
        }

    }

   /* private void MovePlateDown()
    {
        if (transform.position == endPos)
        {
            plateAnim.SetBool("PlateMove", false);
        }
        else
        {
            plateAnim.SetBool("PlateMove", true);
            transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
        }
    }*/

    /*private void MovePlateUp()
    { 
        if (transform.position == initialPos)
        {
            plateAnim.SetBool("PlateMove", false);
        }
        else
        {
            plateAnim.SetBool("PlateMove", true);
        }

    }*/
}

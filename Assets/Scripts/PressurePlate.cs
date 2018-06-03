using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public bool pressured;

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
    }

    private void Update()
    {
        IsPressured();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (name != "PressurePlatePuzzle5")
        {
            if (col.tag == "Player" ||
            col.tag == "HeavyBox" ||
            col.tag == "LightBox")
            {
                pressured = true;
            }
        }
        else
        {
            if (col.tag == "LightBox" && col.transform.Find("DetectIfFilled").GetComponent<ContainerPuzzle>().isFilled)
            {
                pressured = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player" ||
        col.tag == "HeavyBox" ||
        col.tag == "LightBox")
        {
            pressured = false;
        }

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
}

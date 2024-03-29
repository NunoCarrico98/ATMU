﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public Transform waypoint1;
    public Transform waypoint2;
    public bool pressured;
    public bool pressured2; // if you are Nuno: Don't delete this bool!!

    private Animator plateAnim;
    private Collider2D colUp;
    private Collider2D colDown;
    private float timer = 0.17f;

    private void Start()
    {
        if(name != "PressurePlateBigElevator") plateAnim = GetComponent<Animator>();
        colUp = transform.Find("ColliderUp").GetComponent<BoxCollider2D>();
        colDown = transform.Find("ColliderDown").GetComponent<BoxCollider2D>();

        pressured = false;
        colUp.enabled = true;
        colDown.enabled = false;
    }

    private void Update()
    {
        IsPressured();
        if (name != "PressurePlateBigElevator")
        {
            if (pressured)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    transform.Find("Point light").gameObject.SetActive(true);
                }
            }
            else
            {
                timer = 0.17f;
                transform.Find("Point light").gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (name != "PressurePlatePuzzle5")
        {
            if (col.tag == "Player" ||
            col.tag == "HeavyBox" ||
            col.tag == "LightBox" ||
            col.tag == "Ungrababble")
            {
                if (col.tag == "Player" && name == "PressurePlateBigElevator")
                {
                    transform.position = waypoint1.position;
                    pressured2 = true;
                }
                pressured = true;
            }
        }
        if (name == "PressurePlatePuzzle5")
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
            if (name == "PressurePlateBigElevator")
            {
                transform.position = waypoint2.position;
            }
            pressured = false;
            pressured2 = false;
        }

    }

    private void IsPressured()
    {
        if (pressured)
        {
            if (name != "PressurePlateBigElevator")
            {
                plateAnim.SetBool("PlateMove", true);
                colUp.enabled = false;
                colDown.enabled = true;
            }
        }

        if (!pressured)
        {
            if (name != "PressurePlateBigElevator")
            {
                plateAnim.SetBool("PlateMove", false);
                colUp.enabled = true;
                colDown.enabled = false;
            }
        }

    }
}

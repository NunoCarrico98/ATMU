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
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        pressured = false;
    }

}

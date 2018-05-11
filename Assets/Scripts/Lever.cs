using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public bool active;

    private Animator plateAnim;
    private Collider2D colUp;
    private Collider2D colDown;

    private void Start()
    {
        plateAnim = GetComponent<Animator>();
        colUp = transform.Find("ColliderUp").GetComponent<BoxCollider2D>();
        colDown = transform.Find("ColliderDown").GetComponent<BoxCollider2D>();

        active = false;
        colUp.enabled = true;
        colDown.enabled = false;
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
            active = !active;
        }
    }

    private void IsPressured()
    {
        if (active)
        {
            plateAnim.SetBool("PlateMove", true);
        }

        if (!active)
        {
            plateAnim.SetBool("PlateMove", false);
        }

    }
}

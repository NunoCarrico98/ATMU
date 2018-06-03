using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLightBox : MonoBehaviour
{
    public float velocityToDestroyX;
    public float velocityToDestroyY;
    private Transform boxesParent;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "DeathZone" && name != "Container")
        {
            Destroy(transform.gameObject, 0.05f);
        }
    }

    private void Start()
    {
        boxesParent = GameObject.FindGameObjectWithTag("BoxesParent").transform;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "HeavyBox")
        {
            //if (transform.GetComponent<Rigidbody2D>().velocity == Vector2.zero)
            //{
            
                if (col.transform.GetComponent<Rigidbody2D>().velocity.x >= velocityToDestroyX ||
                    col.transform.GetComponent<Rigidbody2D>().velocity.x <= -velocityToDestroyX ||
                    col.transform.GetComponent<Rigidbody2D>().velocity.y >= velocityToDestroyY ||
                    col.transform.GetComponent<Rigidbody2D>().velocity.y <= -velocityToDestroyY)
                {
                    DestroyBox(col);
                }
            //}
            /*else
            {
                if (col.transform.GetComponent<Rigidbody2D>().velocity.x >= velocityToDestroyX ||
                col.transform.GetComponent<Rigidbody2D>().velocity.x <= -velocityToDestroyX ||
                col.transform.GetComponent<Rigidbody2D>().velocity.y >= velocityToDestroyY ||
                col.transform.GetComponent<Rigidbody2D>().velocity.y <= -velocityToDestroyY)
                {
                    DestroyBox(col);
                }
            }*/

        }
    }

    private void DestroyBox(Collision2D col)
    {
        int childCount = transform.childCount - 1;

        if (transform.GetChild(childCount).tag == "Player")
        {
            transform.GetChild(childCount).SetParent(null);
        }
        col.transform.SetParent(boxesParent);
        Destroy(transform.gameObject, 0.05f);
    }
}

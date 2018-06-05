using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLightBox : MonoBehaviour
{
    public float velocityToDestroyX;
    public float velocityToDestroyY;
    public GameObject particlesPrefab;

    private Transform boxesParent;
    private Quaternion initRotation;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "DeathZone" && name != "Container")
        {
            Destroy(transform.gameObject, 0.05f);
        }
    }

    private void Start()
    {
        initRotation = transform.rotation;
        boxesParent = GameObject.FindGameObjectWithTag("BoxesParent").transform;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "HeavyBox")
        {
            if ((col.transform.GetComponent<Rigidbody2D>().velocity.x >= velocityToDestroyX ||
                col.transform.GetComponent<Rigidbody2D>().velocity.x <= -velocityToDestroyX ||
                col.transform.GetComponent<Rigidbody2D>().velocity.y >= velocityToDestroyY ||
                col.transform.GetComponent<Rigidbody2D>().velocity.y <= -velocityToDestroyY) ||
                col.transform.GetComponent<Rigidbody2D>().isKinematic == true ||
                transform.GetComponent<Rigidbody2D>().isKinematic == true)
            {
                DestroyBox(col);
            }
        }
    }

    private void DestroyBox(Collision2D col)
    {
        int childCount = transform.childCount - 1;

        if (transform.GetChild(childCount).tag == "Player")
        {
            transform.GetChild(childCount).SetParent(null);
        }
        if (col.transform.GetComponent<Rigidbody2D>().isKinematic == false)
        {
            col.transform.SetParent(boxesParent);
        }
        Destroy(transform.gameObject, 0.05f);
        Instantiate(particlesPrefab, transform.position, initRotation);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRustFloorBox : MonoBehaviour
{

    public GameObject rustFloor;
    public GameObject ragdollPrefab;
    public GameObject collider1;
    public GameObject collider2;
    public bool activate;

    private Transform parent;
    private int counter = 0;
    private float timer = 0;


    // Use this for initialization
    void Start()
    {
        parent = transform.parent.transform;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "HeavyBox")
        {
            if (col.transform.GetComponent<Rigidbody2D>().velocity.y <= -15)
            {
                activate = true;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRustFloorBox : MonoBehaviour
{

    public GameObject rustFloor;
    public GameObject ragdollPrefab;
    public GameObject collider1;
    public GameObject collider2;

    private Transform parent;
    private int counter = 0;
    private float timer = 0;
    private bool activate;

    // Use this for initialization
    void Start()
    {
        parent = transform.parent.transform;
    }

    private void Update()
    {
        if(activate)
        {
            timer += Time.deltaTime;

            if (counter == 0 && timer > 0.05f)
            {
                //col.transform.position = new Vector2(parent.position.x, parent.position.y + 5);
                Instantiate(ragdollPrefab, new Vector2(parent.position.x, parent.position.y - 3), parent.rotation);
                Destroy(rustFloor);
                Destroy(collider1);
                Destroy(collider2);
                counter++;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "HeavyBox")
        {
            Debug.Log("Merda");
            if (col.transform.GetComponent<Rigidbody2D>().velocity.y <= -15)
            {
                activate = true;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageDoor : MonoBehaviour
{

    public Transform parent;
    public float speed = 10f;
    public float openTime = 0.4f;
    public LayerMask layerMask;

    private bool open = false;
    private bool close = true;
    private static bool allow;
    private static bool allow2 = true;
    private Vector3 openVector;
    private Vector3 closeVector;
    private RaycastHit2D hit;
    private float timer = 0;



    // Use this for initialization
    void Start()
    {
        openVector = new Vector3(parent.position.x, parent.position.y + 2, parent.position.z);
        closeVector = new Vector3(parent.position.x, parent.position.y, parent.position.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (name == "DetectRags")
        {
            SendRaycast();
        }

        if (open && !close)
        {
            Open();
        }

        Close();

    }

    private void Open()
    {
        parent.position = Vector3.MoveTowards(parent.position, openVector, speed * Time.deltaTime);
    }

    private void Close()
    {
        if (open)
        {
            timer += Time.deltaTime;
        }
        if (timer >= openTime)
        {
            close = true;
            timer = 0;
        }
        if (close == true)
        {
            parent.position = Vector3.MoveTowards(parent.position, closeVector, speed * Time.deltaTime);
        }
        if (parent.position == closeVector)
        {
            close = false;
            open = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "LightBox" && name == "OpenCollider" && allow && allow2)
        {
            open = true;
        }

        if(col.tag == "Player" && name == "DetectPlayer")
        {
            allow2 = false;
            if(!allow2)
            {
                open = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player" && name == "DetectPlayer")
        {
            allow2 = true;
        }
    }

    private void SendRaycast()
    {
        hit = Physics2D.Raycast(transform.position, Vector3.right, 4.5f, layerMask);
        if (hit == true && hit.transform.tag == "HeavyBoxPiece3")
        {
            allow = true;
        }
        if(hit == false)
        {
            allow = false;
            open = false;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * 4.5f);
    }
}

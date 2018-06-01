using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageDoor : MonoBehaviour {

    public Transform parent;
    public float speed = 10f;
    public float openTime = 0.4f;
    public LayerMask layerMask;

    private bool open = false;
    private static bool allow;
    private Vector3 openVector;
    private Vector3 closeVector;
    private RaycastHit2D hit;



    // Use this for initialization
    void Start()
    {
        openVector = new Vector3(parent.position.x, parent.position.y + 2, parent.position.z);
        closeVector = new Vector3(parent.position.x, parent.position.y, parent.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Close());

        Debug.Log(allow);

        if (open)
        {
            Open();
        }

        /*if(name == "DetectRags")
        {
            SendRaycast();

        }*/ 
    }

    private void Open()
    {
        parent.position = Vector3.MoveTowards(parent.position, openVector, speed * Time.deltaTime);
    }

    private IEnumerator Close()
    {
        if(open)
        {
            yield return new WaitForSeconds(openTime);
        }
        open = false;
        parent.position = Vector3.MoveTowards(parent.position, closeVector, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "LightBox" && name == "OpenCollider" /*&& allow*/)
        {
            open = true;
        }
    }

    /*private void SendRaycast()
    {
        hit = Physics2D.Raycast(transform.position, Vector3.right, 5, layerMask);
        if (hit == true && hit.transform.tag == "HeavyBoxPiece3")
        {
            allow = true;
        } else
        {
            allow = false;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * 5);
    }*/
}

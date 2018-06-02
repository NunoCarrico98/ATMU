using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerPuzzle : MonoBehaviour {

    public static bool isInside = false;
    public bool isFilled = false;
    public LayerMask layerMask;

    private RaycastHit2D hit;


            // Update is called once per frame
    void FixedUpdate()
    {
        if (name == "DetectIfFilled")
        {
            SendRaycast();
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            isInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            isInside = false;
        }
    }

    private void SendRaycast()
    {
        hit = Physics2D.Raycast(transform.position, Vector3.right, 0.8f, layerMask);
        if (hit == true && hit.transform.tag == "HeavyBoxPiece3")
        {
            isFilled = true;
        }
        if (hit == true && hit.transform.tag != "HeavyBoxPiece3")
        {
            isFilled = false;
        }
    }

    void OnDrawGizmos()
    {
        if (name == "DetectIfFilled")
        {
            Gizmos.color = Color.green;

            Gizmos.DrawLine(transform.position, transform.position + Vector3.right * 0.8f);
        }
    }
}

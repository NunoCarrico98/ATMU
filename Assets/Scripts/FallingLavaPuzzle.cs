using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingLavaPuzzle : MonoBehaviour
{

    public bool kill = false;
    public LayerMask layerMask;

    private RaycastHit2D hit;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SendRaycast();
    }

    private void SendRaycast()
    {
        hit = Physics2D.Raycast(transform.position, Vector3.down, 9, layerMask);
        if (hit == true && hit.transform.tag == "Player")
        {
            kill = true;
        }
        if (hit == true && (hit.transform.tag == "LightBox"
            || hit.transform.tag == "ColliderForBoxes" 
            || hit.transform.tag == "GetPiecesColliderGetPiecesCollider"
            || hit.transform.tag == "BoxCollider"))
        {

            kill = false;
        }
    }
}

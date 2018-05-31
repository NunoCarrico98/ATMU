using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopZRotation : MonoBehaviour
{

    private Transform parent;
    private float colliderForBoxesHeight = 0f;
    private float puzzleColliderHeight = 0f;
    private Quaternion initRotation;

    // Use this for initialization
    void Start()
    {
        parent = transform.parent;
        initRotation = parent.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.name == "ColliderForBoxes")
        {
            transform.position = new Vector3(parent.position.x, parent.position.y + colliderForBoxesHeight, parent.position.z);
            transform.rotation = initRotation;
        }
        if (transform.name == "ColliderForRoom2Puzzle")
        {
            transform.position = new Vector3(parent.position.x, parent.position.y + puzzleColliderHeight, parent.position.z);
            transform.rotation = initRotation;
        }
    }
}

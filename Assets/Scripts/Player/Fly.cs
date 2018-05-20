using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    private Rigidbody2D myRigidBody;
    // Use this for initialization
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        myRigidBody.MovePosition((Vector3)myRigidBody.position + transform.up * Time.deltaTime * 10f);
        if (Input.GetKeyDown(KeyCode.Space))
            transform.position += transform.up * Time.deltaTime * 40.0f;

        transform.Rotate(Input.GetAxis("Horizontal"),0.0f, -Input.GetAxis("Vertical"));

        float terrainHeightWhereWeAre = Terrain.activeTerrain.SampleHeight(transform.position);

        if (terrainHeightWhereWeAre > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x,
            terrainHeightWhereWeAre,
            transform.position.y);
        }
    }
}

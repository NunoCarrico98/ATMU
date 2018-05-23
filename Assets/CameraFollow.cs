using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public float heightOffset = 5f;
    public float minRadius = 0.3f;
    public float fraction;
    public float moveSpeed = 10f;

    private Transform player;
    private GrabBox grabBox;
    private Vector3 direction;
    private float mouseRadius;

    // Use this for initialization
    void Start()
    {

        player = GameObject.Find("Player").transform;

        grabBox = FindObjectOfType<GrabBox>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        FollowPlayer();
        // Test();
    }

    private void FollowPlayer()
    {
        transform.position = new Vector3(player.position.x, player.position.y + heightOffset, transform.position.z);
    }

    private void Test()
    {
        direction = grabBox.directionVector(grabBox.positionOnScreen, grabBox.mouseOnScreen);

        mouseRadius = Mathf.Sqrt(Mathf.Pow(direction.x, 2) + Mathf.Pow(direction.y, 2));

        if (mouseRadius > minRadius)
        {
            MoveCamera();
        }
    }

    private void MoveCamera()
    {
        /*Vector3 moveVector = new Vector3(direction.x / fraction, 
            direction.y / fraction, transform.position.z);

        //transform.position = Vector3.MoveTowards(transform.position, moveVector, moveSpeed * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, moveVector, moveSpeed);*/

        Vector3 moveVector = new Vector3(direction.x / fraction, direction.y / fraction, transform.position.z);

        if (transform.position != moveVector)
        {
            transform.position += new Vector3(moveSpeed, moveSpeed, 0);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerOnOff : MonoBehaviour
{
    public Transform light;
    public bool on;
    public float upSpeed = 1f;
    public float downSpeed = 2f;
    public float upAcceleration = 1.2f;
    public float downAcceleration = 1.2f;

    private Vector3 downVector;
    private Vector3 upVector;
    private bool up = true;
    private bool down = false;
    private float resetDownSpeed;
    private float resetUpSpeed;

    // Use this for initialization
    void Start()
    {
        upVector = new Vector3(transform.position.x, 90, transform.position.z);
        downVector = new Vector3(transform.position.x, 86, transform.position.z);
        resetDownSpeed = downSpeed;
        resetUpSpeed = upSpeed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (on)
        {
            DestroyActivated();
            light.GetComponent<SpriteRenderer>().color = Color.green;
            light.GetComponent<Light>().color = Color.green;
        }
        else
        {
            GoUp();
            light.GetComponent<SpriteRenderer>().color = Color.red;
            light.GetComponent<Light>().color = Color.red;
        }
    }

    private void DestroyActivated()
    {
        if (up && !down)
        {
            GoDown();
        }
        if (down && !up)
        {
            GoUp();
        }
    }

    private void GoUp()
    {
        transform.position = Vector3.MoveTowards(transform.position, upVector, upSpeed * Time.deltaTime);
        upSpeed += upAcceleration;
        if (transform.position == upVector)
        {
            downSpeed = resetDownSpeed;
            down = false;
            up = true;
        }
    }

    private void GoDown()
    {
        transform.position = Vector3.MoveTowards(transform.position, downVector, downSpeed * Time.deltaTime);
        downSpeed += downAcceleration;
        if (transform.position == downVector)
        {
            upSpeed = resetUpSpeed;
            up = false;
            down = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "HeavyBox" || col.transform.tag == "LightBox")
        {
            down = true;
            up = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnaceDoor : MonoBehaviour
{

    public float speed = 50f;

    private OpenTrap openTrap;
    private Quaternion lookRotation;
    private Vector2 openVector;
    private Vector2 closeVector;
    private bool opened = false;
    private float timer = 1f;
    private float resetTimer;

    // Use this for initialization
    void Start()
    {
        openTrap = FindObjectOfType<OpenTrap>();
        openVector = new Vector2(transform.position.x + 5.5f, transform.position.y);
        closeVector = new Vector2(transform.position.x, transform.position.y);
        resetTimer = timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (name != "FurnaceDoor2")
        {
            TrapControll();
        }
        if (name == "FurnaceDoor2")
        {
            TrapControll2();
        }
    }

    private void TrapControll()
    {
        if (openTrap.open == true)
        {
            //transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);
            //lookRotation = Quaternion.LookRotation(Vector3.forward, Vector3.left);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, openSpeed * Time.deltaTime);

            transform.position = Vector2.MoveTowards(transform.position, openVector, speed * Time.deltaTime);
            if ((Vector2)transform.position == openVector) opened = true;

        }
        else if (opened == true)
        {
            //lookRotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, speed * Time.deltaTime);
            transform.position = Vector2.MoveTowards(transform.position, closeVector, speed * Time.deltaTime);
            if ((Vector2)transform.position == closeVector) opened = false;
        }
    }

    private void TrapControll2()
    {
        if (openTrap.open && !opened)
        {
            transform.position = Vector2.MoveTowards(transform.position, openVector, speed * Time.deltaTime);
            if ((Vector2)transform.position == openVector)
            {
                opened = true;
            }


        }
        if (!openTrap.open && opened)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, closeVector, speed * Time.deltaTime);
                if ((Vector2)transform.position == closeVector)
                {
                    opened = false;
                    timer = resetTimer;
                }
            }

        }
    }

}

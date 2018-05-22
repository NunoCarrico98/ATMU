using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnaceDoor : MonoBehaviour
{

    public float speed = 50f;

    private OpenTrap openTrap;
    private Quaternion lookRotation;
    private bool opened = false;
    private Vector2 openVector;
    private Vector2 closeVector;


    // Use this for initialization
    void Start()
    {
        openTrap = FindObjectOfType<OpenTrap>();
        openVector = new Vector2(transform.position.x + 5.5f, transform.position.y);
        closeVector = new Vector2(transform.position.x , transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        TrapControll();
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
            if((Vector2)transform.position == closeVector) opened = false;
        }
    }

}

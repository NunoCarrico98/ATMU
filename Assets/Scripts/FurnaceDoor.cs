using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnaceDoor : MonoBehaviour
{

    public float openSpeed = 50f;

    private OpenTrap openTrap;
    private Quaternion lookRotation;
    private bool opened = false;


    // Use this for initialization
    void Start()
    {
        openTrap = FindObjectOfType<OpenTrap>();
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
            lookRotation = Quaternion.LookRotation(Vector3.forward, Vector3.left);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, openSpeed * Time.deltaTime);

            opened = true;

        }
        else if (opened == true)
        {
            lookRotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, openSpeed * Time.deltaTime);
            //opened = false;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public float conveyorSpeed;
    public bool isOnConveyor = false;


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "ConveyorBelt")
        {
            Debug.Log("IT WORKED!!!");
            isOnConveyor = true;
            conveyorSpeed = col.transform.GetComponent<SurfaceEffector2D>().speed;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.transform.tag == "ConveyorBelt")
        {
            isOnConveyor = false;
        }
    }
}

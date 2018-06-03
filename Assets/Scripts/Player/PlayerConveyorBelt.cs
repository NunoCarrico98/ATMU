using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConveyorBelt : MonoBehaviour
{
    public float conveyorSpeed;
    public bool isOnConveyor = false;
    public bool isOnBox = false;


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "ConveyorBelt")
        {
            isOnConveyor = true;
            conveyorSpeed = col.transform.GetComponent<SurfaceEffector2D>().speed;
        }

        if(col.transform.tag == "LightBox" || col.transform.tag == "HeavyBox")
        {
            transform.parent.SetParent(null);
            isOnBox = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.transform.tag == "ConveyorBelt")
        {
            isOnConveyor = false;
        }

        if (col.transform.tag == "LightBox" || col.transform.tag == "HeavyBox")
        {
            isOnBox = false;
        }
    }
}

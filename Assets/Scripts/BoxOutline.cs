using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxOutline : MonoBehaviour
{
    private GrabBox grabBox;
    private bool getPosition;
    // Use this for initialization
    void Start()
    {
        grabBox = FindObjectOfType<GrabBox>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!grabBox.grabbed && !ContainerPuzzle.isInside)
        {
            if ((grabBox.hit.collider != null && (grabBox.hit.collider.tag == "HeavyBox" || grabBox.hit.collider.tag == "LightBox")) ||
                (grabBox.hitAngle.collider != null && (grabBox.hitAngle.collider.tag == "HeavyBox" || grabBox.hitAngle.collider.tag == "LightBox")))
            {
                if (grabBox.hit == true && grabBox.hitAngle == false)
                {
                    transform.position = grabBox.hit.transform.position;
                    transform.rotation = grabBox.hit.transform.rotation;
                }
                if (grabBox.hitAngle == true)
                {
                    transform.position = grabBox.hitAngle.transform.position;
                    transform.rotation = grabBox.hitAngle.transform.rotation;
                }

                transform.GetComponent<SpriteRenderer>().enabled = true;
                getPosition = true;
            }
            else
            {
                transform.GetComponent<SpriteRenderer>().enabled = false;
                getPosition = false;
            }

            if(getPosition)
            {
                //if (grabBox.hit == true && grabBox.hitAngle == false) transform.position = grabBox.hit.transform.position;
                //if (grabBox.hit == false && grabBox.hitAngle == true) transform.position = grabBox.hitAngle.transform.position;

            }
        }
        else
        {
            transform.GetComponent<SpriteRenderer>().enabled = false;
            getPosition = false;
        }
    }
}

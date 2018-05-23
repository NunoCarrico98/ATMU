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
        if (!grabBox.grabbed)
        {
            if (grabBox.hit.collider != null && (grabBox.hit.collider.tag == "HeavyBox" || grabBox.hit.collider.tag == "LightBox"))
            {
                transform.position = grabBox.hit.transform.position;
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
                transform.position = grabBox.hit.transform.position;
            }
        }
        else
        {
            transform.GetComponent<SpriteRenderer>().enabled = false;
            getPosition = false;
        }
    }
}

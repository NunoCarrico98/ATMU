using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBoxesUp : MonoBehaviour
{

    private bool lightBox;
    private bool heavyBox;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.tag == "HeavyBox" || col.tag == "LightBox"))
        {
            if (transform.parent.tag == "LightBox")
            {
                lightBox = true;
            }

            if (transform.parent.tag == "HeavyBox")
            {
                heavyBox = true;
            }

            if ((transform.parent.name == "Crate1" || transform.parent.name == "Crate2") && transform.parent.gameObject.layer != 11)
            {
                transform.parent.tag = "DontKillPlayer";
                transform.parent.gameObject.layer = 22;
            }

            if ((transform.parent.name != "Crate1" && transform.parent.name != "Crate2") || transform.parent.gameObject.layer == 11)
            {
                transform.parent.tag = "Ungrababble";
                transform.parent.gameObject.layer = 9;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (lightBox)
        {
            lightBox = false;
            transform.parent.tag = "LightBox";

        }

        if (heavyBox)
        {
            heavyBox = false;
            transform.parent.tag = "HeavyBox";
        }
        if (col.tag == "HeavyBox" || col.tag == "LightBox")
        {
            if ((transform.parent.name == "Crate1" || transform.parent.name == "Crate2") && transform.parent.gameObject.layer != 9)
            {
                transform.parent.gameObject.layer = 23;
            }

            if ((transform.parent.name != "Crate1" && transform.parent.name != "Crate2") || transform.parent.gameObject.layer == 9)
            {
                transform.parent.gameObject.layer = 11;
            }
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBoxesUp : MonoBehaviour
{

    private bool lightBox;
    private bool heavyBox;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.gameObject.tag == "HeavyBox" || col.gameObject.tag == "LightBox"))
        {
            if (transform.parent.tag == "LightBox")
            {
                lightBox = true;
            }

            if (transform.parent.tag == "HeavyBox")
            {
                heavyBox = true;
            }

            transform.parent.tag = "Ungrababble";
            transform.parent.gameObject.layer = 9;
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

        transform.parent.gameObject.layer = 11;
    }
}

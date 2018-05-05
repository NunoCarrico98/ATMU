using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBoxesUp : MonoBehaviour
{

    private bool lightBox;
    private bool heavyBox;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "HeavyBox" || col.gameObject.tag == "LightBox" && 
            this.transform.Find("ColliderForBoxes").GetComponent<Collider2D>().tag == "BoxCollider")
        {
            if (this.tag == "LightBox")
            {
                lightBox = true;
            }

            if (this.tag == "HeavyBox")
            {
                heavyBox = true;
            }

            this.tag = "Ungrababble";
            this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (lightBox)
        {
            lightBox = false;
            this.tag = "LightBox";

        }

        if (heavyBox)
        {
            heavyBox = false;
            this.tag = "HeavyBox";
        }

        this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
}

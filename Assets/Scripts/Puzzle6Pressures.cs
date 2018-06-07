using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle6Pressures : MonoBehaviour
{

    public static bool puzzleSolved = false;

    private static int orangeBoxesCount = 0;
    private static int greenBoxesCount = 0;
    private bool placedOranges = false;
    private bool placedGreens = false;

    // Update is called once per frame
    void Update()
    {
        if (orangeBoxesCount > 3) orangeBoxesCount = 3;
        if (greenBoxesCount > 3) greenBoxesCount = 3;

        if (orangeBoxesCount == 3)
        {
            placedOranges = true;
        }
        else
        {
            placedOranges = false;
        }

        if (greenBoxesCount == 2)
        {
            placedGreens = true;
        }
        else
        {
            placedGreens = false;
        }

        if (placedOranges && placedGreens)
        {
            puzzleSolved = true;
        }
        else
        {
            puzzleSolved = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (transform.parent.name == "Orange Button")
        {

            if (col.tag == "LightBox" && col.name == "Crate2")
            {

                orangeBoxesCount++;
                transform.parent.Find("Light (" + (orangeBoxesCount) + ")").gameObject.SetActive(true);
                //Debug.Log("Entered a crate2 on orange button! Count: " + orangeBoxesCount);
            }
        }

        if (transform.parent.name == "Green Button")
        {
            if (col.tag == "LightBox" && col.name == "Crate1")
            {

                greenBoxesCount++;
                transform.parent.Find("Light (" + (greenBoxesCount) + ")").gameObject.SetActive(true);
               // Debug.Log("Entered a crate1 on green button! Count: " + greenBoxesCount);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (transform.parent.name == "Orange Button")
        {
            if (col.tag == "LightBox" && col.name == "Crate2")
            {
                transform.parent.Find("Light (" + (orangeBoxesCount) + ")").gameObject.SetActive(false);
                orangeBoxesCount--;

               // Debug.Log("Exit a crate2 on orange button! Count: " + orangeBoxesCount);
            }
        }

        if (transform.parent.name == "Green Button")
        {
            if (col.tag == "LightBox" && col.name == "Crate1")
            {
                transform.parent.Find("Light (" + (greenBoxesCount) + ")").gameObject.SetActive(false);
                greenBoxesCount--;

               // Debug.Log("Exit a crate1 on green button! Count: " + greenBoxesCount);
            }
        }
    }

}

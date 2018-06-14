using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle8Pressures : MonoBehaviour
{

    public static bool puzzleSolved = false;

    private static int orangeBoxesCount = 0;
    private static int greenBoxesCount = 0;
    private bool placedOranges = false;
    private bool placedGreens = false;

    // Update is called once per frame
    void Update()
    {
        if (!FindObjectOfType<ConfirmLightPuzzle8>().rotate)
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
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "LightBox")
        {
            if (transform.name == "LeftColliderPuzzle")
            {

                orangeBoxesCount++;
            }

            if (transform.name == "RightColliderPuzzle")
            {
                greenBoxesCount++;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "LightBox")
        {
            if (transform.name == "LeftColliderPuzzle")
            {

                orangeBoxesCount--;
            }

            if (transform.name == "RightColliderPuzzle")
            {
                greenBoxesCount--;
            }
        }
    }

}

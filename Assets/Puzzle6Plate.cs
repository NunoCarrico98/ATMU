using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle6Plate : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (!Puzzle6Pressures.puzzleSolved)
        {
            transform.GetComponent<PressurePlate>().enabled = false;
        }
        else
        {
            transform.GetComponent<PressurePlate>().enabled = true;
        }
    }
}

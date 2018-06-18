using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLimitsColliders : MonoBehaviour
{

    public bool moveIt = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            if (name == "OutsideHoleLimits" || name == "Puzzle1Limits")
            {
                Camera.main.GetComponent<CameraFollow>().minX = 9;
                Camera.main.GetComponent<CameraFollow>().minY = 0;
            }

            if (name == "InsideBigElevator" || name == "Puzzle2Limits")
            {
                Camera.main.GetComponent<CameraFollow>().minX = -1000;
                Camera.main.GetComponent<CameraFollow>().minY = -1000;
            }

            if (name == "Puzzle7Limits")
            {
                Camera.main.GetComponent<CameraFollow>().maxX = 370;
                Camera.main.GetComponent<CameraFollow>().maxY = 1000;
                Camera.main.GetComponent<CameraFollow>().minX = -1000;
                Camera.main.GetComponent<CameraFollow>().minY = -1000;
            }

        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPuzzle6Behaviour : MonoBehaviour {

    public Transform checkPoint;
    public float speed;
    public bool inPlace = false;

    private Vector3 initPos;

	// Use this for initialization
	void Start () {
        initPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        if (Puzzle6Pressures.puzzleSolved && inPlace == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, initPos, speed * Time.deltaTime);
        }
        if(Puzzle6Pressures.puzzleSolved == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, checkPoint.position, speed * Time.deltaTime);
            inPlace = false;
        }

        if(transform.position == initPos)
        {
            inPlace = true;
        }
        else
        {
            inPlace = false;
        }
	}
}

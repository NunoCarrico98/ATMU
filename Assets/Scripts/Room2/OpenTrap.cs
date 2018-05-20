using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTrap : MonoBehaviour {

    public bool open = false;
    private FloorCollider floorCollider;
    private PuzzleSolution puzzleSolution;

	// Use this for initialization
	void Start () {
        floorCollider = FindObjectOfType<FloorCollider>();
        puzzleSolution = FindObjectOfType<PuzzleSolution>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (puzzleSolution.close == false)
        {
            if (floorCollider.open || floorCollider.playerEnter)
            {
                open = true;
            }
        }
        else
        {
            open = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmationLight : MonoBehaviour {

    public Sprite redSprite;
    public Sprite greenSprite;
    public SpriteRenderer spriteR;
    private FloorCollider floorCollider;
    private PuzzleSolution pz;

	// Use this for initialization
	void Start () {

        spriteR = GetComponent<SpriteRenderer>();
        floorCollider = FindObjectOfType<FloorCollider>();
        pz = FindObjectOfType<PuzzleSolution>();
    }
	
	// Update is called once per frame
	void Update () {

        if (!floorCollider.redLight && !floorCollider.greenLight)
        {
            spriteR.enabled = false;
        }

        if (!pz.close)
        {
            if (floorCollider.redLight)
            {
                spriteR.enabled = true;
                spriteR.sprite = redSprite;
            }

            if (floorCollider.greenLight)
            {
                spriteR.enabled = true;
                spriteR.sprite = greenSprite;
            }
        }
    }
}

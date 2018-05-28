using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmationLight : MonoBehaviour
{

    public Sprite redSprite;
    public Sprite greenSprite;
    public SpriteRenderer spriteR;
    public Light confirmLight;

    private FloorCollider floorCollider;
    private PuzzleSolution pz;

    // Use this for initialization
    void Start()
    {

        spriteR = GetComponent<SpriteRenderer>();
        floorCollider = FindObjectOfType<FloorCollider>();
        pz = FindObjectOfType<PuzzleSolution>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!floorCollider.redLight && !floorCollider.greenLight)
        {
            spriteR.enabled = false;
            confirmLight.enabled = false;
        }

        if (!pz.close)
        {
            if (floorCollider.redLight)
            {
                spriteR.enabled = true;
                confirmLight.enabled = true;
                confirmLight.color = Color.red;
                spriteR.sprite = redSprite;
            }

            if (floorCollider.greenLight)
            {
                spriteR.enabled = true;
                confirmLight.enabled = true;
                confirmLight.color = Color.green;
                spriteR.sprite = greenSprite;
            }
        }
        else
        {
            spriteR.enabled = true;
            confirmLight.enabled = true;
            confirmLight.color = Color.green;
            spriteR.sprite = greenSprite;
        }
    }
}

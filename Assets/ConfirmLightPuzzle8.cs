using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmLightPuzzle8 : MonoBehaviour
{
    public Transform plate;
    public Transform sprite;
    public Sprite green;
    public Sprite red;
    public float timeOn;

    private float timer = 0;
    private bool activeTimer = false;
    private bool wrong = false;
    private bool correct = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (activeTimer)
        {
            timer += Time.deltaTime;
        }
        if(correct)
        {
            if (timer <= timeOn)
            {
                transform.GetComponent<Light>().enabled = true;
                sprite.GetComponent<SpriteRenderer>().enabled = true;
                transform.GetComponent<Light>().color = Color.green;
                sprite.GetComponent<SpriteRenderer>().sprite = green;
            }
            else
            {
                transform.GetComponent<Light>().enabled = false;
                sprite.GetComponent<SpriteRenderer>().enabled = false;
            }
        }

        if (wrong)
        {
            if (timer <= timeOn)
            {
                transform.GetComponent<Light>().enabled = true;
                sprite.GetComponent<SpriteRenderer>().enabled = true;
                transform.GetComponent<Light>().color = Color.red;
                sprite.GetComponent<SpriteRenderer>().sprite = red;
            }
            else
            {
                transform.GetComponent<Light>().enabled = false;
                sprite.GetComponent<SpriteRenderer>().enabled = false;
            }
        }

        if (plate.GetComponent<PressurePlate>().pressured && Puzzle8Pressures.puzzleSolved)
        {
            activeTimer = true;
            correct = true;
            wrong = false;
            
        }
        if (plate.GetComponent<PressurePlate>().pressured && !Puzzle8Pressures.puzzleSolved)
        {
            activeTimer = true;
            wrong = true;
            correct = false;
        }
        if(!plate.GetComponent<PressurePlate>().pressured)
        {
            if (timer > timeOn)
            {
                activeTimer = false;
                correct = false;
                wrong = false;
                timer = 0;
            }
        }
    }
}

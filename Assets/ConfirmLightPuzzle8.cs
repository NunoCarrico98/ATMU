using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmLightPuzzle8 : MonoBehaviour
{
    public Transform plate;
    public Transform sprite;
    public Transform rightWeighter;
    public Transform leftWeighter;
    public Sprite green;
    public Sprite red;
    public float timeOn;
    public float rotateSpeed;
    public bool rotate = false;

    private Quaternion lookRotation1;
    private Quaternion lookRotation2;
    private Quaternion initRotation;
    private float timer = 0;
    private bool activeTimer = false;
    private bool wrong = false;
    private bool correct = false;
    private bool resetRotation = false;

    // Use this for initialization
    void Start()
    {
        initRotation = rightWeighter.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (activeTimer)
        {
            timer += Time.deltaTime;
        }


        if(rotate)
        {

            //Make Left Wighter turn
            lookRotation1 = Quaternion.LookRotation(Vector3.forward, Vector3.right);
            leftWeighter.rotation = Quaternion.RotateTowards(leftWeighter.rotation, lookRotation1, rotateSpeed);

            //Make Right Wighter turn
            lookRotation2 = Quaternion.LookRotation(Vector3.forward, Vector3.left);
            rightWeighter.rotation = Quaternion.RotateTowards(rightWeighter.rotation, lookRotation2, rotateSpeed);
            resetRotation = true;
        }
        else if(resetRotation)
        {
            //Make Left Wighter turn
            lookRotation1 = Quaternion.LookRotation(Vector3.forward, Vector3.left);
            leftWeighter.rotation = Quaternion.RotateTowards(leftWeighter.rotation, lookRotation1, rotateSpeed);
            
            //Make Right Weighter turn
            lookRotation2 = Quaternion.LookRotation(Vector3.forward, Vector3.right);
            rightWeighter.rotation = Quaternion.RotateTowards(rightWeighter.rotation, lookRotation2, rotateSpeed);

            if(rightWeighter.rotation == initRotation)
            {
                resetRotation = false;
            }
        }

        if (correct)
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

                rotate = true;
            }
            else
            {
                rotate = false;

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
